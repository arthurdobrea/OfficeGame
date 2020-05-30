using UnityEngine;

namespace UnityTemplateProjects
{
    public class OnCollisionClass : MonoBehaviour
    {
        private AudioManager audioManager;

        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("floor"))
            {
                audioManager.Play("ObjectDrop");
            }
        }
    }
}