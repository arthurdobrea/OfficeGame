using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // public Transform target;

    public float smoothSpeed = 0.125f;
    public float rotationSpeed;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Quaternion camturnAgnle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            offset = camturnAgnle * offset;
        }

        Vector3 desiredPosition = ShapeShifterScript.player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(ShapeShifterScript.player.transform);
        
    }
}
