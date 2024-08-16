using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PiUI : MonoBehaviour
{
    public int pieceCount = 4;
    public GameObject piPiece;
    private List<PiPiece> piPieces = new List<PiPiece>();
    private int currentPieceNum = 0;

    public PiData[] piDatas;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            SelectPiece(currentPieceNum);


        UpdateUIScale();
        for(int i = 0; i < piPieces.Count; i++)
        {
            piPieces[i].MouserPosUpdate();
            if (piPieces[i].IsSelected())
                currentPieceNum = i;
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
            piece.SetAngleRange(360.0f / pieceCount);

            float amount = 1.0f / pieceCount;
            piece.SetImageFillAmount(amount);
            piPieces.Add(piece);
        }
    }

    void UpdateUIScale()
    {
        this.transform.localScale = new Vector3((float)Screen.width / (1920 / 4), (float)Screen.height / (1080 / 4), 1);
    }

    void SelectPiece(int InPiPieceNum)
    {
        Debug.Log(InPiPieceNum);
    }

    [System.Serializable]
    public class PiData
    {
        public Sprite imageSprite;
    }
}
