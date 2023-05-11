using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public List<string> deckOfCards = new List<string>(); //Responsible for storing the deck of cards a player can draw from (initalised with values in the engine's editor)

    public List<string> player1Cards = new List<string>(); //Stores cards in player 1's hand
    public List<string> player2Cards = new List<string>(); //Stores cards in player 2's hand

    public BoardManager boardManager; //Initalises reference to the board manager (for token placement and highlighting)

    [SerializeField] private List<CardHighlight> cardGO = new List<CardHighlight>(); //Initalises list used to store all card highlight game objects

    private void Start() //Executed once the application is started
    {
        for (int i = 0; i < 7; i++) //Player 1 and 2 draw 7 cards from the pile 
        {
            player1Cards.Add(DrawNewCard());
        }

        for (int i = 0; i < 7; i++)
        {
            player2Cards.Add(DrawNewCard());
        }

        int j = 0;

        foreach (CardHighlight card in cardGO) //Sets each card game object with the name of the card it should display
        {
            card.cardName = player1Cards[j];
            j++; 
        }
    }

    public string DrawNewCard() //Responsible for drawing a card out the deck for the player
    {
        int randomNumber = Random.Range(0, deckOfCards.Count); //Picks random number in the range of cards in the deck
        string newCard = deckOfCards[randomNumber]; //Picks a random card from the deck
        deckOfCards.Remove(newCard); //Removes that card from the deck
        return newCard; //Outputs the selected card
    }

    public void SwapPlayerHand(string cardName) //Responsible for changing the card game object's displayed card when player's take turns
                                                //Takes in the card that was placed
    {
        int j = 0;

        if (boardManager.isPlayer1) //Determines whether it is player 1 or 2's turn
        {
            player2Cards.Remove(cardName); //Removes the card that was just used from player 2's hand
            player2Cards.Add(DrawNewCard()); //Draws a new card for player 2
            
            foreach (CardHighlight card in cardGO) //Assigns each card game object to the card it should display
            {
                card.cardName = player1Cards[j];
                card.SetImageOnCard(player1Cards[j]);
                j++;
            }
        }

        else
        {
            player1Cards.Remove(cardName); //Same as above but for player 1
            player1Cards.Add(DrawNewCard());

            foreach (CardHighlight card in cardGO)
            {
                card.cardName = player2Cards[j];
                card.SetImageOnCard(player2Cards[j]);
                j++;
            }
        }
    }
}
