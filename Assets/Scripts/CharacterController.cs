using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private bool isGrounded = true;
    public static bool isMoving;

    void Start()
    {
        rb = ShapeShifterScript.player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (ShapeShifterScript.isNewPlayerSwitched)
        {
            ShapeShifterScript.isNewPlayerSwitched = false;
            rb = ShapeShifterScript.player.GetComponent<Rigidbody>();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (Input.anyKey)
        {
            isMoving = true;
            rb.AddForce(movement * speed);
        }
        else
        {
            isMoving = false;
        }
    }
}