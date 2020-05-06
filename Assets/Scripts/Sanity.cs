using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{
    private float maxLevelBeforeSuicide = 100;
    public float sanity = 0;
    private GameObject player;

    void Start()
    {
        player = ShapeShifterScript.player;
        
    }

    void FixedUpdate()
    {
        if (CharacterController.isMoving)
        {
            sanity++;
        }

    }
}
