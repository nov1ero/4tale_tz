using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject ResultPanel;
    public GameObject Panel;
    public Text resultText;
    private string result;
    [Header("Game Settings")]
    public float InitialTime;
    public int WinScore = 2;
    private coinCollect coins;
    private Timer time;


     void Start(){
        coins = FindObjectOfType<coinCollect>();
        time = FindObjectOfType<Timer>();
    }
    public void RestartGame()
    {
        Debug.Log("Button Pressed");
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    void FixedUpdate(){
        Victory();
        Lose();
    }
    void Victory(){
        if (coins.score >= WinScore)
        {
            Time.timeScale = 0f;
            result = "WIN";
            UpdateResultDisplay();
            ResultPanel.SetActive(true);
        }
    }

    void Lose(){
        if (time.currentTime <= 0)
        {
            Time.timeScale = 0f;
            result = "LOSE";
            UpdateResultDisplay();
            ResultPanel.SetActive(true);
        }
    }
    private void UpdateResultDisplay()
    {
        if (resultText != null)
        {
            resultText.text = result;
        }
    }


}
