using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneManagement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wintext;
    [SerializeField] GameObject winScreen;
    
    public void LoadThisScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void GameOver(bool didPlayer1Win)
    {
        winScreen.SetActive(true);
        
        if (didPlayer1Win)
        {
            wintext.text = "Player 1 Wins";
        }
        else
        {
            wintext.text = "Player 2 Wins";
        }
    }
}
