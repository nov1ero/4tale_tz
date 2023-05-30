using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static GameManager gm;
    public Text timerText;
    public float currentTime;
    private Coroutine countdownCoroutine;
    private EventManager eventManager;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        eventManager = FindObjectOfType<EventManager>();
        currentTime = gm.InitialTime;
    }

    private void OnEnable()
    {
        eventManager.coinCollectedEvent.AddListener(TimeIncrease);
    }

    private void OnDisable()
    {
        eventManager.coinCollectedEvent.RemoveListener(TimeIncrease);
    }

    public void TimeIncrease(){
        currentTime = Mathf.Min(currentTime + 5f, gm.InitialTime);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTime > 0f)
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);
        UpdateTimerDisplay();
        if (currentTime <= 0f)
        {
        }
    }
    }

    private void UpdateTimerDisplay()
{
    if (timerText != null)
    {
        timerText.text = currentTime.ToString("F0");
    }
}
}
