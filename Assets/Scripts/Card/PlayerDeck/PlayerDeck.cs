using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeck : Singleton<PlayerDeck>, IPointerDownHandler
{
    List<CardClass> deck = new List<CardClass>();
    public GameObject cardPrefab;

    TextMeshProUGUI textDeck;

    TurnSystemFSM turnSystem;

    protected override void Awake()
    {
        base.Awake();
        textDeck = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        turnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystemFSM>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        // For testing, need to get card by GM.
        for(int i = 0; i < 5; i++)
        {
            deck.Add(CardDatabase.Instance.GetCardByID(1));
            deck.Add(CardDatabase.Instance.GetCardByID(2));
        }
        Shuffle();
    }

    void Update()
    {
        textDeck.text = deck.Count.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("===PlayerDeck===");
        foreach(var card in deck)//.OrderBy(x => x.ID))
        {
            Debug.Log(card.ID + " | " + card.Cost + " | " + card.Name + " | " + card.Description);
        }
        Debug.Log("===========");
    }

    /// <summary> Shuffle PlayerDeck's deck. </summary>
    public void Shuffle()
    {
        CardClass tempCard;
        for (int i = 0; i < deck.Count; i++)
        {
            tempCard = deck[i];
            int random = Random.Range(0, deck.Count);
            deck[i] = deck[random];
            deck[random] = tempCard;
        }
        Debug.Log("===shuffled===");
    }

    /// <summary> Draw a Card and set it's parent. </summary>
    /// <param name="parent">The draw card's parent. </param>
    public void DrawCard(Transform parent)
    {
        // If is card is 0.
        if(deck.Count == 0 && PlayerDeckMuck.Instance.GetMuckCount() != 0)
        {
            foreach(CardClass card in PlayerDeckMuck.Instance.GetMuckAndClearMuck())
            {
                deck.Add(card);
            }
            Shuffle();
        }

        // If is max the card.
        if (Hand.Instance.GetCardCount() >= Hand.Instance.GetMaxCard())
        {
            // Get to deck muck.
            PlayerDeckMuck.Instance.AddToMuck(deck[0]);

            // Remove in deck.
            deck.RemoveAt(0);
        }
        else if(deck.Count != 0)
        {
            // Get the card.
            GameObject card = Instantiate(cardPrefab, parent);
            card.GetComponent<Card>().thisCard = deck[0];

            // Remove in deck.
            deck.RemoveAt(0);

            // Update the hand.
            Hand.Instance.CardInHandChange();
        }
    }

    /// <summary> Add a card to top deck. </summary>
    /// <param name="card"> The card that to put on the top deck. </param>
    public void AddToTopDeck(CardClass card)
    {
        CardClass[] tempDeck = new CardClass[deck.Count];
        deck.CopyTo(tempDeck);
        deck.Clear();

        deck.Add(card);
        foreach(CardClass tempCard in tempDeck)
        {
            deck.Add(tempCard);
        }
    }

    /// <summary> When isPlayerTurn is true, draw start 4 card. </summary>
    public IEnumerator StartTurnDraw()
    {
        Hand.Instance.SetIsDrawing(true);
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            DrawCard(Hand.Instance.transform);
        }
        Hand.Instance.SetIsDrawing(false);
    }
}
