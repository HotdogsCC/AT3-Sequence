using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;

    [SerializeField] private string nameOfTile;
    [SerializeField] private int xPos;
    [SerializeField] private int yPos;

    private bool highlighed = false;


    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
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

    public void HighlightTiles(string selectedCardName)
    {
        if(nameOfTile == selectedCardName)
        {
            image.color = new Color(0f, 0f, 1f, 0.4f);
            highlighed = true;
        }
    }

    public void DehighlightTiles()
    {
        image.color = Color.clear;
        highlighed = false;
    }
}
