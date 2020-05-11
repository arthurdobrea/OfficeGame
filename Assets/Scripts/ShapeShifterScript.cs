using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShifterScript : MonoBehaviour
{
    public Camera camera;
    public GameObject firstPlayer;
    public static GameObject player;

    public static bool isNewPlayerSwitched = false;

    public static bool isGrabbed = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = firstPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.tag.Equals("canCopy"))
                {
                    Destroy(player);
                    player = Instantiate(hit.transform, player.transform.position, Quaternion.identity).gameObject;
                    player.AddComponent<Rigidbody>();
                    isNewPlayerSwitched = true;    
                }
            }
        }
    }
}
