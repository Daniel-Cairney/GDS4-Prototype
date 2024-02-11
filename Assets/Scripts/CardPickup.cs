using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPickup : MonoBehaviour
{
    [SerializeField] private Image CardUISprite;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone");

            if (CardUISprite != null)
            {
                if (!CardUISprite.enabled)  
                {
                    Debug.Log("UI Card on");
                    CardUISprite.enabled = true;
                }
                else
                {
                    Debug.Log("UI Card already on");
                }
            }
           

           // Destroy(gameObject);  
        }
    }
}
