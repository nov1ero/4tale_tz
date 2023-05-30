using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent coinCollectedEvent;

    public void CoinCollected()
    {
        if (coinCollectedEvent != null)
        {
            coinCollectedEvent.Invoke();
        }
    }
}
