using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndPlacePlayer : MonoBehaviour
{
    public GameObject placeWhereItHolds;
    public GameObject placeWhereItPutsPlayer;
    public static bool canGrab = false;
    public static bool canPut;

    public void holdObject()
    {
        ShapeShifterScript.player.transform.position = placeWhereItHolds.transform.position;
    }

    public void putObject()
    {
        ShapeShifterScript.player.transform.position = placeWhereItPutsPlayer.transform.position;
    }

    private void Update()
    {
        if (canGrab)
        {
            holdObject();
        }

        if (canPut)
        {
            putObject();
            canPut = false;
        }
    }
}