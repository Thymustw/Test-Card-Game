using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Card parameter")]
    public CardClass thisCard;
    public int _id, _cost;
    public string _name, _description;
    public bool cardBack;
    public int cardIndex;

    [Header("UI parameter")]
    TextMeshProUGUI costText, nameText, descriptionText;
    Image image;
    Vector3 originRectPos;
    RectTransform rectTransform;
    Canvas cardCanvas;
    CanvasGroup cardCanvasGroup;

    void Awake()
    {
        nameText = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        costText = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        image = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
        descriptionText = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();

        rectTransform = GetComponent<RectTransform>();
        cardCanvas = transform.parent.parent.GetComponent<Canvas>();
        cardCanvasGroup = GetComponent<CanvasGroup>();

        originRectPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if(thisCard != null)
        {
            // Get the propriate in thisCard.
            _id = thisCard.ID;
            _name = thisCard.Name;
            _cost = thisCard.Cost;
            _description = thisCard.Description;

            nameText.text = _name;
            costText.text = _cost.ToString();
            image.sprite = thisCard.ImageSprite;
            descriptionText.text = _description;
        }
    }

    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     //TODO:use observer.
    //     GameManager.Instance.SetBack(true);
    //     PickUp();
    // }

    // public void OnDrag(PointerEventData eventData)
    // {
    //     //rectTransform.anchoredPosition += eventData.delta / cardCanvas.scaleFactor;
    //     cardCanvasGroup.blocksRaycasts = false;
    //     cardCanvasGroup.alpha = 0.6f;

    //     PickUp();
    // }

    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     cardCanvasGroup.blocksRaycasts = true;
    //     cardCanvasGroup.alpha = 1f;
    
    //     //TODO:use observer.
    //     rectTransform.anchoredPosition = originRectPos;
    // }

    // void PickUp()
    // {
    //     Vector2 pos = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2 + 400);
    //     rectTransform.anchoredPosition = pos;
    // }

    public void SetOriginRectPos(Vector2 vector2)
    {
        originRectPos = vector2;
        rectTransform.anchoredPosition = originRectPos;
    }

    /// <summary> Get the back status of card. </summary>
    public bool GetCardBackBool()
    {
        return cardBack;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!Hand.Instance.GetIsDrawing())
        {
            transform.DOScale(1.5f, .25f);
            transform.DOLocalMoveY(originRectPos.y + 150, .25f);
            cardIndex = transform.GetSiblingIndex();
            transform.SetAsLastSibling();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!Hand.Instance.GetIsDrawing())
        {
            transform.DOScale(1f, .25f);
            transform.DOLocalMoveY(originRectPos.y, .25f);
            transform.SetSiblingIndex(cardIndex);
        }
    }
}
