using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPiPiece : MonoBehaviour
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
        thisImage.fillAmount = Amount;
    }

    public void SetUIRotation(Vector3 Rotation)
    {
        Quaternion rotation = Quaternion.Euler(Rotation);
        this.transform.SetLocalPositionAndRotation(new Vector3(0,0,0), rotation);
    }

    public void MouserPosUpdate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 temp = mousePos - (Vector2)transform.position;
        float angle = (Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg);
        Debug.Log(angle);
    }
}
