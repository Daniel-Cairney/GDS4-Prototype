// EventHandler.cs
using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;

    // Event to notify when a card is picked up
    public Action OnCardPickup = delegate { };

    private void Awake()
    {
        Instance = this;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Trigger this method to notify all subscribers that a card is picked up
    public void PickupCard()
    {
        Debug.Log("Card picked up!"); // Add this debug log
        OnCardPickup?.Invoke();
    }
}
