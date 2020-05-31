using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Theme");
    }

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}