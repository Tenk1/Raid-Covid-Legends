using Invector;
using Invector.vCharacterController;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 5;
    private int scoreToNextLevel = 100;
    private float startTime, origWalkSpeed, origRunningSpeed, origAirSpeed;
    private Vector3 startPos;
    public static bool increment;
    public Text coinText;
    public Text scoreText;
    public Image pq;
    public GameManager deathMenu;



    // Update is called once per frame
    void Update()
    {
        if (GameManager.m_GameState == GameState.gameOver)
        {
            scoreText.enabled = false;
            coinText.enabled = false;
            pq.enabled = false;
            return;
        }

        else
        {
            if (score >= scoreToNextLevel)
                LevelUp();
            score = GameObject.FindWithTag("Player").transform.position.z - startPos.z;
            scoreText.text = ((int)score).ToString();
            coinText.GetComponent<Text>().text = Coincoin.coin +"";
        }
    }

    void Start()
    {
        startTime = Time.time;
        startPos = transform.position;
        increment = true;

        origWalkSpeed = GetComponent<vThirdPersonController>().freeSpeed.walkSpeed;
        origRunningSpeed = GetComponent<vThirdPersonController>().freeSpeed.runningSpeed;
        origAirSpeed = GetComponent<vThirdPersonController>().airSpeed;


    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<vThirdPersonController>().freeSpeed.walkSpeed += difficultyLevel / 3;
        GetComponent<vThirdPersonController>().freeSpeed.runningSpeed += difficultyLevel / 3;
        GetComponent<vThirdPersonController>().airSpeed += difficultyLevel / 4;
    }

    public void OnDeath()
    {
        deathMenu.Death();
        deathMenu.ToggleEndMenu(Score.score, Coincoin.coin);

        GetComponent<vThirdPersonController>().freeSpeed.walkSpeed = origWalkSpeed;
        GetComponent<vThirdPersonController>().freeSpeed.runningSpeed = origRunningSpeed;
        GetComponent<vThirdPersonController>().airSpeed = origAirSpeed;

    }
}