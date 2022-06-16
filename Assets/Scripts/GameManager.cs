using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum GameState { gameMenu, gamePlay, gamePause, gameOver}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI, deathMenuUI, pauseFirstButton, deathFirstButton, menuFirstButton, mainMenu, creditMenu, creditFirstButton;
    public float currentMouseX, currentMouseY;
    public Image backgroundImage;
    public Text scoreText, coinText, totalCoinText, highscoreText;
    public static GameState m_GameState;
    private bool isShowned = false;
    public static bool incrementMusic = true;

    public bool IsPlaying { get { return m_GameState == GameState.gamePlay; } }
    // Update is called once per frame

   

    public void Start()
    {
        //music.Play();
       // m_GameState = GameState.gamePlay;
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            ToggleMainMenu();
          //  music.Play();
        }      
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            TogglePauseMenu();
            if (!isShowned)
                return;
        }
    }
    public void TogglePauseMenu()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (m_GameState == GameState.gamePause)
            {
                Resume();
            }
            else if (m_GameState == GameState.gamePlay)
            { 
                Pause();
            }
        }
    }
    public void ToggleEndMenu(float score, int coin)
    {
        
        deathMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scoreText.text = "Vous êtes mort du Coronavirus \n Score : " + ((int)score).ToString();
        coinText.text = coin.ToString() + "      récupérés";
        isShowned = true;
        EventSystem.current.SetSelectedGameObject(null);
        if (!EventSystem.current.alreadySelecting /*&& (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))*/)
            EventSystem.current.SetSelectedGameObject(deathFirstButton);
    }

    public void ToggleMainMenu()
    {
        m_GameState = GameState.gameMenu;
        mainMenu.SetActive(true);
        creditMenu.SetActive(false);
        highscoreText.text = "Highscore : " + ((int) PlayerPrefs.GetFloat("Highscore")).ToString();
        totalCoinText.text = "" + (PlayerPrefs.GetInt("Coin")).ToString();
        EventSystem.current.SetSelectedGameObject(null);
        if (!EventSystem.current.alreadySelecting)
            EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

    public void ToggleCreditMenu()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        if (!EventSystem.current.alreadySelecting)
            EventSystem.current.SetSelectedGameObject(creditFirstButton);
    }

    public void Resume ()
    {
        Time.timeScale = 1f;
        m_GameState = GameState.gamePlay;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
    }

    public void Pause ()
    {
        m_GameState = GameState.gamePause;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        if (!EventSystem.current.alreadySelecting)
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Coincoin.coin = 0;
        Score.score = 0;
        SceneManager.LoadScene("Menu");
        m_GameState = GameState.gameMenu;
    }

    public void Restart()
    {
        m_GameState = GameState.gamePlay;
        Coincoin.coin = 0;
        Score.score = 0;
        SceneManager.LoadScene("Game");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void Death()
    {
        m_GameState = GameState.gameOver;
        
        if (PlayerPrefs.GetFloat("Highscore") < Score.score)
            PlayerPrefs.SetFloat("Highscore", Score.score);

        if (Score.increment)
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + Coincoin.coin);
            Score.increment = false;
        }
        
    }

    public void SelectionPersonnage()
    {
        SceneManager.LoadScene("Character Selection");


    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
