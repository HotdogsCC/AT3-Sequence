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


    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0f, 0.3402588f, 1f, 0.2392157f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.clear;
    }
}
