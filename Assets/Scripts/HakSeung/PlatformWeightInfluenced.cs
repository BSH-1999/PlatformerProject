using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlatformWeightInfluenced : Platform
{
    [Header("WeightInflueneced")]
    const float maxFallYpos = 5.0f;
    const float fallingSpeed = 3.0f;
    const float minRideTime = 1.0f;

    [SerializeField]
    float rideTime;
    [SerializeField]
    bool isGetOnPlatform = false;
    [SerializeField]
    bool isRunToGetOnEvent = false;
   


    protected override IEnumerator GetOnEvent()
    {
        isRunToGetOnEvent = true;
        rideTime = 0;

        while (isGetOnPlatform)
        {
            yield return null;
            rideTime += Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
            if (transform.position.y <= InitPlatformPos.y - maxFallYpos) { break; }
        }

        while (!isGetOnPlatform)
        {
            yield return null;
            transform.Translate(Vector3.up * Time.deltaTime * fallingSpeed);
            if(transform.position.y >= InitPlatformPos.y) { break; }
        }   

        isRunToGetOnEvent = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGetOnPlatform = true;
        if (!isRunToGetOnEvent)  StartCoroutine(GetOnEvent());
    }

    private void OnCollisionExit(Collision collision)
    {
        if(rideTime > 1)  isGetOnPlatform = false;
    }
}
