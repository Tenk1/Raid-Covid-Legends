using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionCharacterButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform centerselection;
    public Transform selectionContainer;
    

    private void Start()
    {
      //  PlayerPrefs.SetInt("Jotaro", 0);
      //  PlayerPrefs.SetInt("Bomberman", 0);
      //  PlayerPrefs.SetInt("Trooper", 0);
        //PlayerPrefs.SetInt("Highscore", 0);
        //PlayerPrefs.SetInt("Coin", 0);
    }

    public void OnClickCharacter()
    {
        float dis = centerselection.position.x - transform.position.x;
        SelectionCharacterController.newPose = new Vector3(selectionContainer.position.x + dis, selectionContainer.position.y, selectionContainer.position.z);
        SelectionCharacterController.SelectMove = true;
    }

    public void SelectCharacter(int whichCharacter)
    {
        if ((PlayerPrefs.GetInt("Bomberman") == 1 && whichCharacter == 3) || (PlayerPrefs.GetInt("Trooper") == 1 && whichCharacter == 2) || (PlayerPrefs.GetInt("Jotaro") == 1 && whichCharacter == 1) || whichCharacter == 0)
        {
            PlayerPrefs.SetInt("CharacterSelected", whichCharacter);
            SceneManager.LoadScene("Game");
            GameManager.m_GameState = GameState.gamePlay;

        }
        else
        {
            if (SelectionCharacterController.cost[whichCharacter] <= PlayerPrefs.GetInt("Coin"))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SelectionCharacterController.cost[whichCharacter]);
                if(whichCharacter == 1)
                {
                    PlayerPrefs.SetInt("Jotaro", 1);
                }
                if (whichCharacter == 2)
                {
                    PlayerPrefs.SetInt("Trooper", 1);
                }
                if (whichCharacter == 3)
                {
                    PlayerPrefs.SetInt("Bomberman", 1);
                }
            }
        }
    }
}
