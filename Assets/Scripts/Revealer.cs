using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Revealer : MonoBehaviour
{
    [SerializeField] private GameObject blocker; //Initialises game object resonponsible for hiding the cards while the players switch turns
    [SerializeField] public TextMeshProUGUI playerTurnText; //UI component that display's the next player's turn

    private void Start() //Runs when the game starts
    {
        playerTurnText.text = SceneManagementing.player1Name + "'s Turn"; //Displays player 1's turn
    }

    public void Hide() //Reveals the cards
    {
        blocker.SetActive(false);
    }

    public void Show() //Blocks the cards
    {
        blocker.SetActive(true);
    }
}
