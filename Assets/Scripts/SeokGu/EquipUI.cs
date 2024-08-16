using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour
{
    private GameObject itemPiecePrefab;
    private ItemPiece itemPiece;

    void Start()
    {
        itemPiecePrefab = GameObject.Find("ItemPiece");
        itemPiece = itemPiecePrefab.GetComponent<ItemPiece>();
    }

    public void ChangeIcon(Sprite InSprite)
    {
        itemPiece.itemIcon.sprite = InSprite;
        itemPiece.itemIcon.color = new Color(1, 1, 1, 1);
    }
}
