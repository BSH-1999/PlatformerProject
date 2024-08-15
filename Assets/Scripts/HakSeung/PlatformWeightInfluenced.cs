using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlatformWeightInfluenced : Platform
{
    [Header("WeightInflueneced")]
    float maxFallYpos = 5.0f;
    float fallingSpeed = 3.0f;  
    bool isGetOnPlatform = false;


    protected override IEnumerator GetOnEvent()
    {
        float stayTime = 0.0f;
        while (isGetOnPlatform || Time.deltaTime != 1f)
        {
            yield return null;
            stayTime += Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * fallingSpeed);
            if (transform.position.y <= InitPlatformPos.y - maxFallYpos) { stayTime = 0; break; }
        }

        while(!isGetOnPlatform || Time.deltaTime != 1)
        {
            yield return null;
            stayTime += Time.deltaTime;

            transform.Translate(Vector3.up * Time.deltaTime * fallingSpeed);
            if(transform.position.y >= InitPlatformPos.y) { stayTime = 0; break; }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGetOnPlatform = true;

        StartCoroutine(GetOnEvent());
    }

    private void OnCollisionExit(Collision collision)
    {
        isGetOnPlatform = false;
    }
}
