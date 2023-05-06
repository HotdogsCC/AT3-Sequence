using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public List<string> deckOfCards = new List<string>();

    public List<string> player1Cards = new List<string>();
    public List<string> player2Cards = new List<string>();

    public BoardManager boardManager;

    [SerializeField] private List<CardHighlight> cardGO = new List<CardHighlight>();

    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            player1Cards.Add(DrawNewCard());
        }

        for (int i = 0; i < 7; i++)
        {
            player2Cards.Add(DrawNewCard());
        }

        int j = 0;

        foreach (CardHighlight card in cardGO)
        {
            card.cardName = player1Cards[j];
            j++; 
        }
    }

    public string DrawNewCard()
    {
        int randomNumber = Random.Range(0, deckOfCards.Count);
        string newCard = deckOfCards[randomNumber];
        deckOfCards.Remove(newCard);
        return newCard;
    }

    public void SwapPlayerHand(string cardName)
    {
        int j = 0;

        if (boardManager.isPlayer1)
        {
            player2Cards.Remove(cardName);
            player2Cards.Add(DrawNewCard());
            
            foreach (CardHighlight card in cardGO)
            {
                card.cardName = player1Cards[j];
                card.SetImageOnCard(player1Cards[j]);
                j++;
            }
        }

        else
        {
            player1Cards.Remove(cardName);
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
