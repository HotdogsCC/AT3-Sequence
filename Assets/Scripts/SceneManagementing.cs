using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SceneManagementing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;  //Initialises text element for displaying the winner
    [SerializeField] GameObject winScreen; //Initialises the Game Object responsible for displaying the win screen
    [SerializeField] GameObject aboutScreen; //Initialises the Game Object responsible for displaying the about screen

    [SerializeField] public static string player1Name = "Player 1"; //Stores the player names
    [SerializeField] public static string player2Name = "Player 2";

    [SerializeField] private Toggle rowsToggle; //Stores whether the game is finding 1 or 2 rows to win
    public static int rowsToFind = 1; //Stores amount of rows required to win

    private Scene startScene; //Initialises start scene
    
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

    public void QuitTheGame() //Quits the game
    {
        Application.Quit();
    }

    public void SetPlayer1Name(string pName) //Sets player 1's username
    {
        player1Name = pName;
    }

    public void SetPlayer2Name(string pName) //Sets player 2's username
    {
        player2Name = pName;
    }

    public void SetRows() //Sets the amount of rows the game needs to find for the game to finish
    {
        if (rowsToggle.isOn)
        {
            rowsToFind = 2;
        }
        else
        {
            rowsToFind = 1;
        }
    }

    private void Start() //Runs when the app starts
    {
        startScene = SceneManager.GetSceneByBuildIndex(0); //Sets the start scene as the first scene
        if (SceneManager.GetActiveScene() == startScene) //Checks to if it the start scene is running
        {
            if (rowsToFind == 2) //Sets what the toggle should display
            {
                rowsToggle.isOn = true;
            }
            else
            {
                rowsToggle.isOn = false;
            }
        }
    }

    public void OpenAbout()
    {
        aboutScreen.SetActive(true);
    }

    public void CloseAbout()
    {
        aboutScreen.SetActive(false);
    }
}
