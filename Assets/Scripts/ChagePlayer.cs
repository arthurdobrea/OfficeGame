using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChagePlayer : MonoBehaviour
{
    public CinemachineFreeLook cinemachineFreeLook;
    public Rigidbody rb;
    public static bool isMoving;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShapeShifterScript.isNewPlayerSwitched)
        {
            cinemachineFreeLook.Follow = ShapeShifterScript.player.transform;
            cinemachineFreeLook.LookAt = ShapeShifterScript.player.transform;
            ShapeShifterScript.isNewPlayerSwitched = false;
            rb = ShapeShifterScript.player.GetComponent<Rigidbody>();
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (Input.anyKey)
        {
            isMoving = true;
            rb.AddForce(movement * 14);
        }
        else
        {
            isMoving = false;
        }
    }
}
