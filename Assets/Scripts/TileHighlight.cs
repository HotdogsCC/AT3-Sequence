using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;

    [SerializeField] private string nameOfTile;
    [SerializeField] private int xPos;
    [SerializeField] private int yPos;

    private bool highlighed = false;

    private GameObject tokenImage;

    private TileHighlight[] tileHighlightList;
    private CardHighlight[] cardHighlightList;

    [SerializeField] BoardManager boardManager;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        tokenImage = gameObject.transform.GetChild(0).gameObject;

        tileHighlightList = FindObjectsOfType<TileHighlight>();
        cardHighlightList = FindObjectsOfType<CardHighlight>();
    }

    // Update is called once per frame

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (highlighed)
        {
            image.color = new Color(0f, 1f, 0.04959822f, 0.254902f);
        }
        else
        {
            image.color = new Color(1f, 0.25f, 0.3326685f, 0.254902f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (highlighed)
        {
            image.color = new Color(0f, 0f, 1f, 0.4f);
        }
        else
        {
            image.color = Color.clear;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (highlighed)
        {
            Debug.Log("I clicked!");

            if (boardManager.gameBoardArray[yPos, xPos] == 1)
            {
                tokenImage.SetActive(false);
                boardManager.gameBoardArray[yPos, xPos] = 0;
            }

            else
            {
                tokenImage.SetActive(true);
                boardManager.gameBoardArray[yPos, xPos] = 1;
            }

            foreach (CardHighlight card in cardHighlightList)
            {
                card.TokenWasPlaced();
            }

            foreach (TileHighlight tiles in tileHighlightList)
            {
                tiles.DehighlightTiles();
            }
        }

   
    }

    public void HighlightTiles(string selectedCardName)
    {
        if (nameOfTile == selectedCardName || selectedCardName == "JC" || selectedCardName == "JD")
        {
            if(boardManager.gameBoardArray[yPos, xPos] == 0)
            {
                image.color = new Color(0f, 0f, 1f, 0.4f);
                highlighed = true;
            }

        }

        else if (selectedCardName == "JH" || selectedCardName == "JS")
        {
            if (boardManager.gameBoardArray[yPos, xPos] == 1)
            {
                image.color = new Color(0f, 0f, 1f, 0.4f);
                highlighed = true;
            }
        }
    }

    public void DehighlightTiles()
    {
        image.color = Color.clear;
        highlighed = false;
    }
}
