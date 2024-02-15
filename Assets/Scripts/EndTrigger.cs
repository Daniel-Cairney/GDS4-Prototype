using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private float sceneToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // SceneManager.LoadScene(sceneToLoad);
        }
    }
}
