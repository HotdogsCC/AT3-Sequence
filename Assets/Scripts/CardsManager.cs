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

        player1Cards = BubbleSort(player1Cards); //Sorts player 1 and 2 cards
        player2Cards = BubbleSort(player2Cards);

        foreach (CardHighlight card in cardGO) //Sets each card game object with the name of the card it should display
        {
            card.cardName = player1Cards[j];
            j++; 
        }
    }

    public string DrawNewCard() //Responsible for drawing a card out the deck for the player
    {
        if(deckOfCards.Count > 0)
        {
            int randomNumber = Random.Range(0, deckOfCards.Count); //Picks random number in the range of cards in the deck
            string newCard = deckOfCards[randomNumber]; //Picks a random card from the deck
            deckOfCards.Remove(newCard); //Removes that card from the deck
            return newCard; //Outputs the selected card
        }

        else
        {
            return "JC"; //If theres no cards left in the deck to draw from, keep giving two eyed jacks so the game can end
        }
    }

        

    public void SwapPlayerHand(string cardName) //Responsible for changing the card game object's displayed card when player's take turns
                                                //Takes in the card that was placed
    {
        int j = 0;

        if (boardManager.isPlayer1) //Determines whether it is player 1 or 2's turn
        {
            player2Cards.Remove(cardName); //Removes the card that was just used from player 2's hand
            player2Cards.Add(DrawNewCard()); //Draws a new card for player 2
            player2Cards = BubbleSort(player2Cards); //Sorts the cards
            
            foreach (CardHighlight card in cardGO) //Assigns each card game object to the card it should display
            {
                card.cardName = player1Cards[j];
                card.SetImageOnCard(player1Cards[j]);
                j++;
            }
        }

        else
        {
            player1Cards.Remove(cardName); //Removes the card that was just used from player 1's hand
            player1Cards.Add(DrawNewCard()); //Draws a new card for player 1
            player1Cards = BubbleSort(player1Cards); //Sorts the cards

            foreach (CardHighlight card in cardGO) //Assigns each card game object to the card it should display
            {
                card.cardName = player2Cards[j];
                card.SetImageOnCard(player2Cards[j]);
                j++;
            }
        }
    }

    private int GetCardValueForSorting(string _cardName) //Assigns rank to each card for sorting
    {
        switch (_cardName)
        {
            case "AC":
                return 0;

            case "2C":
                return 1;

            case "3C":
                return 2;

            case "4C":
                return 3;

            case "5C":
                return 4;

            case "6C":
                return 5;

            case "7C":
                return 6;

            case "8C":
                return 7;

            case "9C":
                return 8;

            case "10C":
                return 9;

            case "JC":
                return 48;

            case "QC":
                return 10;

            case "KC":
                return 11;



            case "AH":
                return 12;

            case "2H":
                return 13;

            case "3H":
                return 14;

            case "4H":
                return 15;

            case "5H":
                return 16;

            case "6H":
                return 17;

            case "7H":
                return 18;

            case "8H":
                return 19;

            case "9H":
                return 20;

            case "10H":
                return 21;

            case "JH":
                return 49;

            case "QH":
                return 22;

            case "KH":
                return 23;



            case "AS":
                return 24;

            case "2S":
                return 25;

            case "3S":
                return 26;

            case "4S":
                return 27;

            case "5S":
                return 28;

            case "6S":
                return 29;

            case "7S":
                return 30;

            case "8S":
                return 31;

            case "9S":
                return 32;

            case "10S":
                return 33;

            case "JS":
                return 50;

            case "QS":
                return 34;

            case "KS":
                return 35;



            case "AD":
                return 36;

            case "2D":
                return 37;

            case "3D":
                return 38;

            case "4D":
                return 39;

            case "5D":
                return 40;

            case "6D":
                return 41;

            case "7D":
                return 42;

            case "8D":
                return 43;

            case "9D":
                return 44;

            case "10D":
                return 45;

            case "JD":
                return 51;

            case "QD":
                return 46;

            case "KD":
                return 47;

            default:
                return 999;
        }
    }

    private string GetCardNameForSorting(int _cardValue) //Converts the sorted rank back into the card names
    {
        switch (_cardValue)
        {
            case 0:
                return "AC";

            case 1:
                return "2C";

            case 2:
                return "3C";

            case 3:
                return "4C";

            case 4:
                return "5C";

            case 5:
                return "6C";

            case 6:
                return "7C";

            case 7:
                return "8C";

            case 8:
                return "9C";

            case 9:
                return "10C";

            case 48:
                return "JC";

            case 10:
                return "QC";

            case 11:
                return "KC";



            case 12:
                return "AH";

            case 13:
                return "2H";

            case 14:
                return "3H";

            case 15:
                return "4H";

            case 16:
                return "5H";

            case 17:
                return "6H";

            case 18:
                return "7H";

            case 19:
                return "8H";

            case 20:
                return "9H";

            case 21:
                return "10H";

            case 49:
                return "JH";

            case 22:
                return "QH";

            case 23:
                return "KH";



            case 24:
                return "AS";

            case 25:
                return "2S";

            case 26:
                return "3S";

            case 27:
                return "4S";

            case 28:
                return "5S";

            case 29:
                return "6S";

            case 30:
                return "7S";

            case 31:
                return "8S";

            case 32:
                return "9S";

            case 33:
                return "10S";

            case 50:
                return "JS";

            case 34:
                return "QS";

            case 35:
                return "KS";



            case 36:
                return "AD";

            case 37:
                return "2D";

            case 38:
                return "3D";

            case 39:
                return "4D";

            case 40:
                return "5D";

            case 41:
                return "6D";

            case 42:
                return "7D";

            case 43:
                return "8D";

            case 44:
                return "9D";

            case 45:
                return "10D";

            case 51:
                return "JD";

            case 46:
                return "QD";

            case 47:
                return "KD";

            default:
                return "null";
        }
    }

    private List<string> BubbleSort(List<string> listToSort) //Sorts the deck of cards inputted
    {
        List<int> cardValueList = new List<int>(); //Temp list for storing values
        List<string> listToReturn = new List<string>(); //Temp list for storing card names

        foreach (var card in listToSort) //Stores each card as it's value into the value list
        {
            cardValueList.Add(GetCardValueForSorting(card));
        }

        bool swapped = true; //Used for looping until sorted

        while (swapped) //Sorts cards
        {
            swapped = false;
            int i = 0; //Counter for each card
            while (i<6)
            {
                if(cardValueList[i] > cardValueList[i + 1]) //Checks two cards and swaps them if they're not sorted
                {
                    var temp = cardValueList[i];
                    cardValueList[i] = cardValueList[i + 1];
                    cardValueList[i + 1] = temp;
                    swapped = true;
                }

                i++; //Increment
            }

        }
        foreach (var item in cardValueList) //Converts the sorted values back into cards
        {
            listToReturn.Add(GetCardNameForSorting(item));
        }
        return listToReturn; //Returns the sorted deck

    }
}
