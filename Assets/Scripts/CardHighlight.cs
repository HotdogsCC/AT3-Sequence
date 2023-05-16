using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //Initialise Card Sprites for Rendering
    [Header("Cards")]
    [SerializeField] Sprite aceC;
    [SerializeField] Sprite twoC;
    [SerializeField] Sprite threeC;
    [SerializeField] Sprite fourC;
    [SerializeField] Sprite fiveC;
    [SerializeField] Sprite sixC;
    [SerializeField] Sprite sevenC;
    [SerializeField] Sprite eightC;
    [SerializeField] Sprite nineC;
    [SerializeField] Sprite tenC;
    [SerializeField] Sprite jackC;
    [SerializeField] Sprite queenC;
    [SerializeField] Sprite kingC;

    [SerializeField] Sprite aceH;
    [SerializeField] Sprite twoH;
    [SerializeField] Sprite threeH;
    [SerializeField] Sprite fourH;
    [SerializeField] Sprite fiveH;
    [SerializeField] Sprite sixH;
    [SerializeField] Sprite sevenH;
    [SerializeField] Sprite eightH;
    [SerializeField] Sprite nineH;
    [SerializeField] Sprite tenH;
    [SerializeField] Sprite jackH;
    [SerializeField] Sprite queenH;
    [SerializeField] Sprite kingH;

    [SerializeField] Sprite aceS;
    [SerializeField] Sprite twoS;
    [SerializeField] Sprite threeS;
    [SerializeField] Sprite fourS;
    [SerializeField] Sprite fiveS;
    [SerializeField] Sprite sixS;
    [SerializeField] Sprite sevenS;
    [SerializeField] Sprite eightS;
    [SerializeField] Sprite nineS;
    [SerializeField] Sprite tenS;
    [SerializeField] Sprite jackS;
    [SerializeField] Sprite queenS;
    [SerializeField] Sprite kingS;

    [SerializeField] Sprite aceD;
    [SerializeField] Sprite twoD;
    [SerializeField] Sprite threeD;
    [SerializeField] Sprite fourD;
    [SerializeField] Sprite fiveD;
    [SerializeField] Sprite sixD;
    [SerializeField] Sprite sevenD;
    [SerializeField] Sprite eightD;
    [SerializeField] Sprite nineD;
    [SerializeField] Sprite tenD;
    [SerializeField] Sprite jackD;
    [SerializeField] Sprite queenD;
    [SerializeField] Sprite kingD;


    //Initialise other stuff
    [Header("Other")]
    public Image cardImage; //Image component for rendering image
    public string cardName; //Stores name of the card assigned to the card component
    public bool cardSelected = false; //Stores whether the card is currently sellected
    private TileHighlight[] tileHighlightList; //Stores tiles
    private CardHighlight[] cardHighlightList; //Stores other card components
    public LastCard lastCard; //Reference to the LastCard script
    private AudioSource cardSFX;

    [SerializeField] CardsManager cardsManager; //Reference to CardManager script


    private void Start() //When the game starts
    {
        cardImage = GetComponent<Image>(); //Assign the image component
        cardSFX = GetComponent<AudioSource>();

        tileHighlightList = FindObjectsOfType<TileHighlight>(); //Add all tiles to the list
        cardHighlightList = FindObjectsOfType<CardHighlight>(); //Add all other card componets to the list
        StartCoroutine(WaitThenDraw()); //Waits for the cards to be assigned names before setting images
    }

    private IEnumerator WaitThenDraw() //Waits a little bit before executing
    {
        yield return new WaitForSeconds(0f);
        SetImageOnCard(cardName); //Sets image on card
    }

    public void SetImageOnCard(string _cardName) //Converts the name of the card to the sprite to display
    {
        switch (_cardName)
        {
            case "AC":
                cardImage.sprite = aceC;
                break;

            case "2C":
                cardImage.sprite = twoC;
                break;

            case "3C":
                cardImage.sprite = threeC;
                break;

            case "4C":
                cardImage.sprite = fourC;
                break;

            case "5C":
                cardImage.sprite = fiveC;
                break;

            case "6C":
                cardImage.sprite = sixC;
                break;

            case "7C":
                cardImage.sprite = sevenC;
                break;

            case "8C":
                cardImage.sprite = eightC;
                break;

            case "9C":
                cardImage.sprite = nineC;
                break;

            case "10C":
                cardImage.sprite = tenC;
                break;

            case "JC":
                cardImage.sprite = jackC;
                break;

            case "QC":
                cardImage.sprite = queenC;
                break;

            case "KC":
                cardImage.sprite = kingC;
                break;



            case "AH":
                cardImage.sprite = aceH;
                break;

            case "2H":
                cardImage.sprite = twoH;
                break;

            case "3H":
                cardImage.sprite = threeH;
                break;

            case "4H":
                cardImage.sprite = fourH;
                break;

            case "5H":
                cardImage.sprite = fiveH;
                break;

            case "6H":
                cardImage.sprite = sixH;
                break;

            case "7H":
                cardImage.sprite = sevenH;
                break;

            case "8H":
                cardImage.sprite = eightH;
                break;

            case "9H":
                cardImage.sprite = nineH;
                break;

            case "10H":
                cardImage.sprite = tenH;
                break;

            case "JH":
                cardImage.sprite = jackH;
                break;

            case "QH":
                cardImage.sprite = queenH;
                break;

            case "KH":
                cardImage.sprite = kingH;
                break;



            case "AS":
                cardImage.sprite = aceS;
                break;

            case "2S":
                cardImage.sprite = twoS;
                break;

            case "3S":
                cardImage.sprite = threeS;
                break;

            case "4S":
                cardImage.sprite = fourS;
                break;

            case "5S":
                cardImage.sprite = fiveS;
                break;

            case "6S":
                cardImage.sprite = sixS;
                break;

            case "7S":
                cardImage.sprite = sevenS;
                break;

            case "8S":
                cardImage.sprite = eightS;
                break;

            case "9S":
                cardImage.sprite = nineS;
                break;

            case "10S":
                cardImage.sprite = tenS;
                break;

            case "JS":
                cardImage.sprite = jackS;
                break;

            case "QS":
                cardImage.sprite = queenS;
                break;

            case "KS":
                cardImage.sprite = kingS;
                break;



            case "AD":
                cardImage.sprite = aceD;
                break;

            case "2D":
                cardImage.sprite = twoD;
                break;

            case "3D":
                cardImage.sprite = threeD;
                break;

            case "4D":
                cardImage.sprite = fourD;
                break;

            case "5D":
                cardImage.sprite = fiveD;
                break;

            case "6D":
                cardImage.sprite = sixD;
                break;

            case "7D":
                cardImage.sprite = sevenD;
                break;

            case "8D":
                cardImage.sprite = eightD;
                break;

            case "9D":
                cardImage.sprite = nineD;
                break;

            case "10D":
                cardImage.sprite = tenD;
                break;

            case "JD":
                cardImage.sprite = jackD;
                break;

            case "QD":
                cardImage.sprite = queenD;
                break;

            case "KD":
                cardImage.sprite = kingD;
                break;

            default:
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) //Activates when the cursor is above a card
    {
        if (!cardSelected) //Checks if the card is not selected
        {
            cardImage.color = new Color(0.8820755f, 0.9924621f, 1f, 1f); //Changes colour to an opaque blue
        }
        
    }

    public void OnPointerExit(PointerEventData eventData) //Activates when the cursor is no longer above the card
    {
        if (!cardSelected) //Checks if the card is not selected
        {
            cardImage.color = Color.white; //Changes colour to white
        }

    }

    public void OnPointerClick(PointerEventData eventData) //Activates when the cursor clicks on the card
    {
        lastCard.cardName = cardName; //Saves the last card used as the card clicked

        foreach (CardHighlight card in cardHighlightList) //Makes all other cards white (so they no longer appear selected)
        {
            card.cardImage.color = Color.white;
        }

        foreach (TileHighlight tiles in tileHighlightList) //Dehighlights all tiles
        {
            tiles.DehighlightTiles();
        }

        if (!cardSelected) //Checks to see whether this card is already selected
        {
            cardSFX.Play();
            foreach (TileHighlight tiles in tileHighlightList) //Highlight tiles which match the card
            {
                tiles.HighlightTiles(cardName);
            }
            cardImage.color = new Color(0.6179246f, 1f, 0.9856288f, 1f); //Sets the image to a bright blue (appear selected)
            foreach (CardHighlight card in cardHighlightList) //Assigns all other card components as not selected
            {
                card.cardSelected = false;
            }
            cardSelected = true; //Assigns this card as selected
        }
        else //If this card is already selected, it deselects this card when clicked on
        {
            cardImage.color = Color.white; //Removes colour (dehighlights)
            foreach (CardHighlight card in cardHighlightList) //Makes all cards not selected
            {
                card.cardSelected = false;
            }
        }
    }

    public void TokenWasPlaced() //Activates when a token is placed
    {
        cardImage.color = Color.white; //Dehighlights the card
        if (cardSelected)
        {
            cardsManager.SwapPlayerHand(cardName); //Swaps the cards from displaying player 1 to player 2 or vise versa
                                                   //Passes the card placed so that it can be removed from the player's hand
        }
        cardSelected = false; //This card is no longer selected
    }
}
