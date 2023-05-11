using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneManagement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;  //Initialises text element for displaying the winner
    [SerializeField] GameObject winScreen; //Initialises the Game Object responsible for displaying the win screen
    
    public void LoadThisScene(string scene) //General function accessible in the editor to load a scene
    {
        SceneManager.LoadScene(scene);
    }

    public void GameOver(bool didPlayer1Win) //Executes once someone gets a row of 5, passes through which player won
    {
        winScreen.SetActive(true); //Displays win screen
        
        if (didPlayer1Win) //Displays which player won
        {
            winText.text = "Player 1 Wins";
        }
        else
        {
            winText.text = "Player 2 Wins";
        }
    }
}
