using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeckMuck : Singleton<PlayerDeckMuck>, IPointerDownHandler
{
    List<CardClass> deckMuck = new List<CardClass>();
    TextMeshProUGUI textMuck;

    protected override void Awake()
    {
        base.Awake();
        textMuck = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMuck.text = deckMuck.Count.ToString();
    }

    /// <summary> Add a card to deck muck. </summary>
    /// <param name="card"> The card that to put to the deck muck. </param>
    public void AddToMuck(CardClass card)
    {
        deckMuck.Add(card);
    }

    /// <summary> Add a card to deck muck. </summary>
    /// <param name="card"> The card that to put to the deck muck. </param>
    public CardClass[] GetMuckAndClearMuck()
    {
        CardClass[] tempDeckMuck = new CardClass[deckMuck.Count];
        deckMuck.CopyTo(tempDeckMuck);
        deckMuck.Clear();

        return tempDeckMuck;
    }

    public int GetMuckCount()
    {
        return deckMuck.Count;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("===PlayerDeckMuck===");
        foreach(var card in deckMuck)//.OrderBy(x => x.ID))
        {
            Debug.Log(card.ID + " | " + card.Cost + " | " + card.Name + " | " + card.Description);
        }
        Debug.Log("===========");
    }
}
