using UnityEngine;
using UnityEngine.AI;

public class FullAnimationController : MonoBehaviour
{
    public Animator animationController;

    private float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setToIdle()
    {
        animationController.SetBool("isWalking", false);
        animationController.SetBool("isTalking", false);
        animationController.SetBool("isLooting", false);
        animationController.SetBool("isSiting", false);
    }

    public void setToWalking()
    {
        animationController.SetBool("isWalking", true);
        animationController.SetBool("isTalking", false);
        animationController.SetBool("isLooting", false);
        animationController.SetBool("isSiting", false);
    }

    public void setToTalking()
    {
        animationController.SetBool("isWalking", false);
        animationController.SetBool("isTalking", true);
        animationController.SetBool("isLooting", false);
        animationController.SetBool("isSiting", false);
    }

    public void setToLooting()
    {
        animationController.SetBool("isWalking", false);
        animationController.SetBool("isTalking", false);
        animationController.SetBool("isLooting", true);
        animationController.SetBool("isSiting", false);
    }

    public void setToSiting()
    {
        animationController.SetBool("isWalking", false);
        animationController.SetBool("isTalking", false);
        animationController.SetBool("isLooting", false);
        animationController.SetBool("isSiting", true);
    }
}