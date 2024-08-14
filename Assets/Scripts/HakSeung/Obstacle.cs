using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    private int Damage { get; set; } = 1;

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
