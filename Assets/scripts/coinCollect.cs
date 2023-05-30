using UnityEngine.UI;
using UnityEngine;

public class coinCollect : MonoBehaviour
{
    public Text scoreText;
    [SerializeField] float turnSpeed = 90f;
    public int score = 0;
    private EventManager eventManager;
    public ParticleSystem particleEffect;


    void Start()
    {
       eventManager = FindObjectOfType<EventManager>(); 
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            score++;
            if (particleEffect != null)
            {
                ParticleSystem newEffect = Instantiate(particleEffect, transform.position, Quaternion.identity);
            }
            eventManager.CoinCollected();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }

     private void OnEnable()
    {
        eventManager.coinCollectedEvent.AddListener(UpdateScoreDisplay);
    }

    private void OnDisable()
    {
        eventManager.coinCollectedEvent.RemoveListener(UpdateScoreDisplay);
    }

    public void UpdateScoreDisplay()
{
    if (scoreText != null)
    {
        scoreText.text = score.ToString("F0");
    }
}
}
