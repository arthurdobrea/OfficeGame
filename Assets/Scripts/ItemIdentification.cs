using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdentification : MonoBehaviour
{
    public string[] possibleProps;
    public GameObject[] pointNearPlacePosition;
    public GameObject[] placePosition;

    private static Dictionary<string, PlaceHolder> PlaceObjectMap;

    private void Start()
    {
        PlaceObjectMap = new Dictionary<string, PlaceHolder>();

        for (int i = 0; i < possibleProps.Length; ++i)
        {
            PlaceHolder placeHolder = new PlaceHolder(pointNearPlacePosition[i], placePosition[i]);

            PlaceObjectMap.Add(possibleProps[i], placeHolder);
        }
    }

    public static PlaceHolder getPLacePoint(string nameOfProp)
    {
        return PlaceObjectMap[nameOfProp];
    }

    private void Update()
    {
        // Debug.Log("here             " + PlaceObjectMap["onTable(clone)"]);
    }
}