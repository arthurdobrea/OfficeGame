using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAndTalkController : MonoBehaviour
{
    public Animator animatorController;

    private float taimer = 0;
    private bool flagWhatAnimationToRun = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        taimer -= Time.deltaTime;
        if (taimer <= 0)
        {
            taimer = Random.Range(1, 30);
            
            flagWhatAnimationToRun = !flagWhatAnimationToRun;
            
            switch (flagWhatAnimationToRun)
            {
                case true:
                {
                    setIdleAnimation();
                    break;
                }
                case false:
                {
                    setTalkAnimation();
                    break;
                }
            }
        }
       
    }

    private void setIdleAnimation()
    {
        animatorController.SetBool("isIdle", true);
        animatorController.SetBool("isTalking", false);
    }
    
    
    private void setTalkAnimation()
    {
        animatorController.SetBool("isIdle", false);
        animatorController.SetBool("isTalking", true);
    }
}