using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class HealthPiece : MonoBehaviour
{
    Image thisImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        thisImage = GetComponent<Image>();
    }

    public void SetImageFillAmount(float Amount)
    {
        Debug.Log(Amount);
        thisImage.fillAmount = Amount;
    }

    public void SetUIPosition(Vector3 InPosition)
    {
        this.transform.localPosition = InPosition;
    }
}
