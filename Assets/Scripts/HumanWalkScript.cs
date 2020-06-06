using UnityEngine;
using UnityEngine.AI;

public class HumanWalkScript : MonoBehaviour
{
    public GameObject[] pointOfInterest;
    public GameObject placeWhereItHolds;
    public NavMeshAgent agent;
    public GameObject currentLocationToMove;

    private State state;
    private static string nameOfAiThatHoldsPlayer;
    private PlaceHolder placeHolder;
    private FullAnimationController animationController;
    private AudioManager audioManager;
    private bool audioAlreadyPlayed = false;

    private enum State
    {
        SCOUT,
        MOVING_TO_PLAYER,
        GRAB_PLAYER,
        PUT_PLAYER
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        animationController = GetComponent<FullAnimationController>();
        currentLocationToMove = pointOfInterest[Random.Range(0, 7)];
        state = State.SCOUT;
    }

    private void Update()
    {
        switch (state)
        {
            case State.SCOUT:
            {
                if (inFOV() && decideIfPlayerShouldBePicked())
                {
                    if (!ShapeShifterScript.isGrabbed)
                    {
                        nameOfAiThatHoldsPlayer = transform.name;
                        state = State.MOVING_TO_PLAYER;
                    }
                }
                else
                {
                    animationController.setToWalking();
                    findNewPlaceToGo();
                    moveToPlace();
                }

                break;
            }
            case State.MOVING_TO_PLAYER:
            {
                if (nameOfAiThatHoldsPlayer.Equals(transform.name))
                {
                    if (Vector3.Distance(transform.position, ShapeShifterScript.player.transform.position) < 1)
                    {
                        state = State.GRAB_PLAYER;
                        ShapeShifterScript.isGrabbed = true;
                    }
                    else
                    {
                        moveToPlayer();
                    }
                }
                else
                {
                    state = State.SCOUT;
                }

                break;
            }
            case State.GRAB_PLAYER:
            {
                if (!audioAlreadyPlayed)
                {
                    audioManager.Play("PickUp");
                    audioAlreadyPlayed = true;
                }

                placeHolder = ItemIdentification.getPLacePoint(ShapeShifterScript.player.name);

                movePlayerToTable();

                ShapeShifterScript.player.GetComponent<Rigidbody>().useGravity = false;

                if (Vector3.Distance(transform.position, placeHolder.placeNear.transform.position) < 1)
                {
                    ShapeShifterScript.player.transform.position = placeHolder.placePoint.transform.position;
                    ShapeShifterScript.isGrabbed = false;
                    state = State.SCOUT;
                    audioAlreadyPlayed = false;

                    ShapeShifterScript.player.GetComponent<Rigidbody>().useGravity = true;
                }

                break;
            }
        }
    }

    private void moveToPlace()
    {
        agent.SetDestination(currentLocationToMove.transform.position);
    }

    private void moveToPlayer()
    {
        agent.SetDestination(ShapeShifterScript.player.transform.position);
    }

    private void findNewPlaceToGo()
    {
        if (Vector3.Distance(transform.position, currentLocationToMove.transform.position) <= 1)
        {
            int range = Random.Range(0, 7);
            currentLocationToMove = pointOfInterest[range];
        }
    }

    private void movePlayerToTable()
    {
        ShapeShifterScript.player.transform.position = placeWhereItHolds.transform.position;
        agent.SetDestination(placeHolder.placeNear.transform.position);
    }

    private bool inFOV()
    {
        return FovDetection.inFOV(transform, ShapeShifterScript.player.transform, 75, 3);
    }

    private bool DecideIfPlayerShouldBeplacedNearWall()
    {
        if (ShapeShifterScript.player.transform.name == "nearWall(Clone)" && 
            !ShapeShifterScript.isNearWall)
        {
            Debug.Log("true");
            return true;
        }
        Debug.Log("false");
        return false;
    }

    private bool DecideIfPlayerShouldBePlacedOnTable()
    {
        if (ShapeShifterScript.player.transform.name == "onTable(Clone)" &&
            ShapeShifterScript.player.transform.position.y < 0.8f)
        {
            return true;
        }

        return false;
    }

    private bool DecideIfPlayerShouldBePlacedInGarbage()
    {
        if (ShapeShifterScript.player.transform.name == "inGarbage(Clone)" &&
            ShapeShifterScript.player.transform.position.y < 0.8f)
        {
           
            return true;
        }
        
        return false;
    }

    public bool decideIfPlayerShouldBePicked()
    {
        return DecideIfPlayerShouldBePlacedOnTable() || DecideIfPlayerShouldBePlacedInGarbage() ||  DecideIfPlayerShouldBeplacedNearWall();
    }
}