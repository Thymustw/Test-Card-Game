using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    Image _hoverImage;
    // Start is called before the first frame update
    void Awake()
    {
        _hoverImage = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(this.transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            Hand.Instance.CardInHandChange();
            GameManager.Instance.SetBack(false);
        }
        else GameManager.Instance.SetBack(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerPress != null)
            _hoverImage.color = new Color(_hoverImage.color.r, _hoverImage.color.g, _hoverImage.color.b, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _hoverImage.color = new Color(_hoverImage.color.r, _hoverImage.color.g, _hoverImage.color.b, 0);
    }
}
