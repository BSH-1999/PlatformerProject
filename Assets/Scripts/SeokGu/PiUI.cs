using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PiUI : MonoBehaviour
{
    public int pieceCount = 4;
    public GameObject piPiece;
    private List<PiPiece> piPieces = new List<PiPiece>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIScale();

        foreach (PiPiece pi in piPieces)
        {
            if (pi.gameObject.activeInHierarchy)
            {
                pi.MouserPosUpdate();
            }
        }
    }

    // 실행시 설정한 pieceCount만큼 UI PiPiece생성 및 Instantiate시키고 PiUI에 Child로 추가
    void Init()
    {
        for (int i = 0; i < pieceCount; i++)
        {
            float z = 360.0f / pieceCount * i;
            PiPiece piece = piPiece.GetComponent<PiPiece>();
            piece = Instantiate(piece);
            piece.transform.SetParent(transform);
            piece.Init();
            piece.SetUIRotation(new Vector3(0, 0, z));

            float amount = 1.0f / pieceCount;
            piece.SetImageFillAmount(amount);
            piPieces.Add(piece);
        }
    }

    void UpdateUIScale()
    {
        this.transform.localScale = new Vector3((float)Screen.width / (1920 / 4), (float)Screen.height / (1080 / 4), 1);
    }
}
