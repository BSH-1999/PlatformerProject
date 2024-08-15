using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public int pieceCount = 3;
    public float currentHealth = 3;
    public float distance = 120.0f;
    public bool bTest;

    public GameObject healthPiece;

    private List<HealthPiece> healthPieces = new List<HealthPiece>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(bTest == true)
            UpdateCurrentHealth();
    }

    void Init()
    {
        for (int i = 0; i < pieceCount; i++)
        {
            float z = 360.0f / pieceCount * i;
            HealthPiece piece = healthPiece.GetComponent<HealthPiece>();
            piece = Instantiate(piece);
            piece.transform.SetParent(transform);
            piece.Init();
            piece.SetUIPosition(new Vector3(distance * i, 0, 0));
            piece.SetImageFillAmount(1.0f);

            healthPieces.Add(piece);
        }
    }

    void UpdateCurrentHealth()
    {
        float current = currentHealth;
        for (int i = 0; i < pieceCount; i++)
        {
            current -= 1;
            if(current >= 0)
            {
                healthPieces[i].SetImageFillAmount(1.0f);
            }
            else
            {
                if (current < -0.5f)
                    healthPieces[i].SetImageFillAmount(0);
                else if (current < 0)
                    healthPieces[i].SetImageFillAmount(0.5f);
            }
        }
    }
}
