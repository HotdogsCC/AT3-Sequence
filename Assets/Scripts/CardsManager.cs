using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public List<string> deckOfCards = new List<string>();

    private void Start()
    {
        AddCardsToDeck();
    }

    private void AddCardsToDeck()
    {
        deckOfCards.Add("AC");
        deckOfCards.Add("2C");
        deckOfCards.Add("3C");
        deckOfCards.Add("4C");
        deckOfCards.Add("5C");
        deckOfCards.Add("6C");
        deckOfCards.Add("7C");
        deckOfCards.Add("8C");
        deckOfCards.Add("9C");
        deckOfCards.Add("10C");
        deckOfCards.Add("JC");
        deckOfCards.Add("QC");
        deckOfCards.Add("KC");

        deckOfCards.Add("AH");
        deckOfCards.Add("2H");
        deckOfCards.Add("3H");
        deckOfCards.Add("4H");
        deckOfCards.Add("5H");
        deckOfCards.Add("6H");
        deckOfCards.Add("7H");
        deckOfCards.Add("8H");
        deckOfCards.Add("9H");
        deckOfCards.Add("10H");
        deckOfCards.Add("JH");
        deckOfCards.Add("QH");
        deckOfCards.Add("KH");

        deckOfCards.Add("AS");
        deckOfCards.Add("2S");
        deckOfCards.Add("3S");
        deckOfCards.Add("4S");
        deckOfCards.Add("5S");
        deckOfCards.Add("6S");
        deckOfCards.Add("7S");
        deckOfCards.Add("8S");
        deckOfCards.Add("9S");
        deckOfCards.Add("10S");
        deckOfCards.Add("JS");
        deckOfCards.Add("QS");
        deckOfCards.Add("KS");

        deckOfCards.Add("AD");
        deckOfCards.Add("2D");
        deckOfCards.Add("3D");
        deckOfCards.Add("4D");
        deckOfCards.Add("5D");
        deckOfCards.Add("6D");
        deckOfCards.Add("7D");
        deckOfCards.Add("8D");
        deckOfCards.Add("9D");
        deckOfCards.Add("10D");
        deckOfCards.Add("JD");
        deckOfCards.Add("QD");
        deckOfCards.Add("KD");

        deckOfCards.Add("AC");
        deckOfCards.Add("2C");
        deckOfCards.Add("3C");
        deckOfCards.Add("4C");
        deckOfCards.Add("5C");
        deckOfCards.Add("6C");
        deckOfCards.Add("7C");
        deckOfCards.Add("8C");
        deckOfCards.Add("9C");
        deckOfCards.Add("10C");
        deckOfCards.Add("JC");
        deckOfCards.Add("QC");
        deckOfCards.Add("KC");

        deckOfCards.Add("AH");
        deckOfCards.Add("2H");
        deckOfCards.Add("3H");
        deckOfCards.Add("4H");
        deckOfCards.Add("5H");
        deckOfCards.Add("6H");
        deckOfCards.Add("7H");
        deckOfCards.Add("8H");
        deckOfCards.Add("9H");
        deckOfCards.Add("10H");
        deckOfCards.Add("JH");
        deckOfCards.Add("QH");
        deckOfCards.Add("KH");

        deckOfCards.Add("AS");
        deckOfCards.Add("2S");
        deckOfCards.Add("3S");
        deckOfCards.Add("4S");
        deckOfCards.Add("5S");
        deckOfCards.Add("6S");
        deckOfCards.Add("7S");
        deckOfCards.Add("8S");
        deckOfCards.Add("9S");
        deckOfCards.Add("10S");
        deckOfCards.Add("JS");
        deckOfCards.Add("QS");
        deckOfCards.Add("KS");

        deckOfCards.Add("AD");
        deckOfCards.Add("2D");
        deckOfCards.Add("3D");
        deckOfCards.Add("4D");
        deckOfCards.Add("5D");
        deckOfCards.Add("6D");
        deckOfCards.Add("7D");
        deckOfCards.Add("8D");
        deckOfCards.Add("9D");
        deckOfCards.Add("10D");
        deckOfCards.Add("JD");
        deckOfCards.Add("QD");
        deckOfCards.Add("KD");

        Debug.Log(deckOfCards);
    }

    public string DrawNewCard(string placedCard)
    {
        int randomNumber = Random.Range(0, deckOfCards.Count);
        string newCard = deckOfCards[randomNumber];
        deckOfCards.Remove(newCard);
        deckOfCards.Add(placedCard);
        Debug.Log(deckOfCards);
        return newCard;
    }
}
