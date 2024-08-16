using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiPiece : MonoBehaviour
{
    Image thisImage;

    public GameObject itemPiece;

    private float angleRange;
    private bool select = false;

    void Start()
    {

    }

    public void Init()
    {
        thisImage = GetComponent<Image>();

        ItemPiece piece = itemPiece.GetComponent<ItemPiece>();
        piece.Init();
    }

    public void SetData()
    {

    }

    public void SetImageFillAmount(float Amount)
    {
        thisImage.fillAmount = Amount;
    }

    public void SetUIRotation(Vector3 Rotation)
    {
        Quaternion rotation = Quaternion.Euler(Rotation);
        transform.SetLocalPositionAndRotation(new Vector3(0,0,0), rotation);
    }

    public void SetAngleRange(float InAngleRange)
    {
        angleRange = InAngleRange;
    }

    // MousePosition값으로 Angle을 계산하고 그 값과 Piece의 Rotation값과 비교해서 UI크기 조정
    public void MouserPosUpdate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 temp = mousePos - (Vector2)transform.position;
        float angle = ((Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg) + 270) % 360;
        if (angle >= transform.rotation.eulerAngles.z && angle < transform.rotation.eulerAngles.z + angleRange)
        {
            transform.localScale = new Vector3(2, 2, 2);
            select = true;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            select = false;
        }
    }

    public bool IsSelected() { return select; }
}
