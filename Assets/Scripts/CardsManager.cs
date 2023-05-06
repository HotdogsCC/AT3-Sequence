using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public List<string> deckOfCards = new List<string>();

    public string DrawNewCard(string placedCard)
    {
        int randomNumber = Random.Range(0, deckOfCards.Count);
        string newCard = deckOfCards[randomNumber];
        deckOfCards.Remove(newCard);
        if(placedCard != null)
        {
            deckOfCards.Add(placedCard);
        }
        return newCard;
    }
}
