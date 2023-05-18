using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image; //Stores the highlight image (it changes colour depending on the state of a tile)

    [SerializeField] private string nameOfTile; //Stores the name of the tile (E.g. KD means King of Diamonds)
    [SerializeField] private int xPos; //Stores the x position
    [SerializeField] private int yPos; //Stores the y position

    public LastCard lastCard; //Reference to the LastCard script

    private bool highlighed = false; //Stores whether the tile is highlighted

    private GameObject tokenImageGO; //Reference to the token image gameobject that displays ontop of the tile
    private Image tokenImageComponent; //Reference to the token image IMAGE component

    private TileHighlight[] tileHighlightList; //Stores other tiles
    private CardHighlight[] cardHighlightList; //Stores cards

    [SerializeField] BoardManager boardManager; //Reference to board manager script

    private bool wasIJustClicked = false; //Stores whether this tile was clicked

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>(); //Sets the image component
        tokenImageGO = gameObject.transform.GetChild(0).gameObject; //Sets the token gameobject
        tokenImageComponent = tokenImageGO.GetComponent<Image>(); //Sets the token image component

        tileHighlightList = FindObjectsOfType<TileHighlight>(); //Sets tiles
        cardHighlightList = FindObjectsOfType<CardHighlight>(); //Sets cards
    }

    public void OnPointerEnter(PointerEventData eventData) //Activates when the mouse hovers over the tile
    {
        if (highlighed) //Checks whether the tile is highlighted 
        {
            image.color = new Color(0f, 1f, 0.04959822f, 0.254902f); //Displays green
        }
        else
        {
            image.color = new Color(1f, 0.25f, 0.3326685f, 0.254902f); //Displays red
        }
    }

    public void OnPointerExit(PointerEventData eventData) //Activates when the mouse hovers off the tile
    {
        if (highlighed) //Checks whether the tile is highlighted 
        {
            image.color = new Color(0f, 0f, 1f, 0.4f); //Displays blue highlight colour
        }
        else
        {
            if (wasIJustClicked) //Checks whether this tile was the last location clicked
            {
                image.color = new Color(1f, 1f, 0f, 0.4f); //Displays yellow
            }
            else
            {
                image.color = Color.clear; //Displays white
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) //Activates when the tile is clicked
    {
        if (highlighed) //Checks whether the tile is highlighed
        { 
            lastCard.SetImageOnCard(); //Sets the last card to display the card that was just used

            if (boardManager.isPlayer1) //Checks whether it is player 1 or 2 that just went
            {
                tokenImageComponent.color = new Color(0f, 0f, 1f, 0.7f); //Sets the token blue
            }
            else
            { 
                tokenImageComponent.color = new Color(0f, 1f, 0f, 0.7f); //Sets the token green
            }

            if (boardManager.gameBoardArray[yPos, xPos] == 1) //Checks whether there is a token already there
            {
                //If this activates, it means it was a 1 eyed jack
                tokenImageGO.SetActive(false); //Removes the token from the board
                boardManager.UpdateBoard(xPos, yPos, true); //Updates the 2D array storing token positions
            }

            else
            {
                tokenImageGO.SetActive(true); //Adds the token from the board
                boardManager.UpdateBoard(xPos, yPos, false); //Updates the 2D array storing token positions
            }

            foreach (CardHighlight card in cardHighlightList) //Lets each card know that a token was just placed
            {
                card.TokenWasPlaced();
            }

            foreach (TileHighlight tiles in tileHighlightList) //Dehighlights and resets all other tiles
            {
                tiles.wasIJustClicked = false;
                tiles.DehighlightTiles();
            }
            wasIJustClicked = true; //Sets this tile as the tile that a token was just placed on
            DehighlightTiles(); //Dehighlights this tile
        }

   
    }

    public void HighlightTiles(string selectedCardName)
    {
        //Checks that this tile is assigned to the card selected, or if the card selected is a 2 eyed jack
        if (nameOfTile == selectedCardName || selectedCardName == "JC" || selectedCardName == "JD") 
        {
            if(boardManager.gameBoardArray[yPos, xPos] == 0) //Checks that the tile is free
            {
                image.color = new Color(0f, 0f, 1f, 0.4f); //Changes the tile to be blue
                highlighed = true; //Sets the tile as highlighted
            }

        }

        //Checks whether the card selected is a 1 eyed jack
        else if (selectedCardName == "JH" || selectedCardName == "JS")
        {
            if (boardManager.gameBoardArray[yPos, xPos] == 1) //Checks that a tile is here to remove
            {
                image.color = new Color(0f, 0f, 1f, 0.4f); //Changes the tile to be blue
                highlighed = true; //Sets the tile as highlighted
            }
        }
    }

    public void DehighlightTiles()
    {
        if (wasIJustClicked) //Checks whether this tile is the most recent move
        {
            image.color = new Color(1f, 1f, 0f, 0.4f); //Displays this tile as yellow
        }
        else
        {
            image.color = Color.clear; //Displays the tile as while
        }

        highlighed = false; //Sets the tile as not highlighted
    }
}
