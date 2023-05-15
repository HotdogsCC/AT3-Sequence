using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneManagement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;  //Initialises text element for displaying the winner
    [SerializeField] GameObject winScreen; //Initialises the Game Object responsible for displaying the win screen

    [SerializeField] public static string player1Name = "Player 1";
    [SerializeField] public static string player2Name = "Player 2";
    
    public void LoadThisScene(string scene) //General function accessible in the editor to load a scene
    {
        SceneManager.LoadScene(scene);
    }

    public void GameOver(bool didPlayer1Win) //Executes once someone gets a row of 5, passes through which player won
    {
        winScreen.SetActive(true); //Displays win screen
        
        if (didPlayer1Win) //Displays which player won
        {
            winText.text = player1Name + " Wins!";
        }
        else
        {
            winText.text = player2Name + " Wins!";
        }
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void SetPlayer1Name(string pName)
    {
        player1Name = pName;
    }

    public void SetPlayer2Name(string pName)
    {
        player2Name = pName;
    }
}
