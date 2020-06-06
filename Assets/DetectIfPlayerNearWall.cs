using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectIfPlayerNearWall : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShapeShifterScript.isNearWall = true;
            Debug.Log(other.name + "has entered trigger zone");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShapeShifterScript.isNearWall = false;
            Debug.Log(other.name + "has exit trigger zone");
        }
    }
}