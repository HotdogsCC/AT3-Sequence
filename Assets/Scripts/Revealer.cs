using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Revealer : MonoBehaviour
{
    [SerializeField] private GameObject blocker; //Initialises game object resonponsible for hiding the cards while the players switch turns
    [SerializeField] public TextMeshProUGUI playerTurnText;

    private void Start()
    {
        playerTurnText.text = SceneManagement.player1Name + "'s Turn";
    }

    public void Hide() //Hides the cards
    {
        blocker.SetActive(false);
    }

    public void Show() //Shows the cards
    {
        blocker.SetActive(true);
    }
}
