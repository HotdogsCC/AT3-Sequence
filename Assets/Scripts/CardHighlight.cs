using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //Cards
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

    [Header("Other")]
    Image cardImage;
    [SerializeField] string cardName;

    private void Start()
    {
        cardImage = GetComponent<Image>();
        SetImageOnCard(cardName);

    }

    private void SetImageOnCard(string _cardName)
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardImage.color = new Color(0.8820755f, 0.9924621f, 1f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardImage.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cardImage.color = new Color(0.6179246f, 1f, 0.9856288f, 1f);
    }
}
