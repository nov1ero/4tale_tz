using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
   public Transform[] SpawnPoints;
    private int currentSpawnPointIndex = 0;
    public Transform Coin;
    private EventManager eventManager;

    private void Start()
    {
        SpawnCoin();
        eventManager = FindObjectOfType<EventManager>();
    }

    private void SpawnCoin()
    {
        int randomIndex = Random.Range(0, SpawnPoints.Length);
        while (randomIndex == currentSpawnPointIndex)
        {
            randomIndex = Random.Range(0, SpawnPoints.Length);
        }

        currentSpawnPointIndex = randomIndex;

        if (Coin != null)
        {
            Coin.position = SpawnPoints[currentSpawnPointIndex].position;
        }
        else
        {
            Coin = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere)).transform;
            Coin.position = SpawnPoints[currentSpawnPointIndex].position;
        }
    }

    private void OnEnable()
    {
        eventManager.coinCollectedEvent.AddListener(CollectCoin);
    }

    private void OnDisable()
    {
        eventManager.coinCollectedEvent.RemoveListener(CollectCoin);
    }

    public void CollectCoin()
    {
        SpawnCoin();
    }
}
