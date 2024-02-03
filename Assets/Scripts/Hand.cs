using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hand : Singleton<Hand>
{
    const int MAX_CARD_NUM = 7;
    bool isDrawing;
    // Start is called before the first frame update
    void Start()
    {
        CardInHandChange();
        //PlayerDeck.Instance.RegisterHandToPlayerDeck(gameObject.GetComponent<Hand>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary> Update card's position in HandArea. </summary>
    public void CardInHandChange()
    {
        Card[] cards = GetComponentsInChildren<Card>();

        int mediun = cards.Length / 2;
        for(int i = 0; i < cards.Length; i++)
        {
            Card tempCard = cards[i];
            if (cards.Length % 2 == 1)
            {
                //TODO: Need to change it great.
                float xPos = (i - mediun) * 150;
                Vector2 tempCardPos = new Vector2(xPos, 0);
                tempCard.SetOriginRectPos(tempCardPos);
            }

            if (cards.Length % 2 == 0)
            {
                //TODO: Need to change it great.
                float xPos = (i - mediun) * 150 + 75;
                Vector2 tempCardPos = new Vector2(xPos, 0);
                tempCard.SetOriginRectPos(tempCardPos);
            }
        }
    }

    /// <summary> Hand card throw out. </summary>
    /// /// <param name="index"> The card of index that to go to muck. </param>
    public void GoToMuck(int index)
    {
        Card tempCard = transform.GetChild(index).GetComponent<Card>();
        PlayerDeckMuck.Instance.AddToMuck(tempCard.thisCard);

        Destroy(tempCard.gameObject);
        CardInHandChange();
    }


    /// <summary> Hand card back to deck. </summary>
    /// /// <param name="index"> The card of index that to go to top deck. </param>    public void GoToTopDeck(int index)
    public void GoToTopDeck(int index)
    {
        Card tempCard = transform.GetChild(index).GetComponent<Card>();
        PlayerDeck.Instance.AddToTopDeck(tempCard.thisCard);

        Destroy(tempCard.gameObject);
        CardInHandChange();
    }

    /// <summary> End turn and throw to deck muck. </summary>
    public void EndTurnThrow()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject tempCard = transform.GetChild(i).gameObject;

            CardClass card = tempCard.GetComponent<Card>().thisCard;
            PlayerDeckMuck.Instance.AddToMuck(card);

            Destroy(tempCard);
        }
    }

    public int GetCardCount()
    {
        int sum = transform.GetComponentsInChildren<Card>().Length;
        return sum;
    }

    public int GetMaxCard()
    {
        return MAX_CARD_NUM;
    }

    public bool GetIsDrawing()
    {
        return isDrawing;
    }

    /// <summary> Get the sprite by ID. </summary>
    /// <param name="id"> The card ID of sprite you want to search. </param>
    public void SetIsDrawing(bool value)
    {
        isDrawing = value;
    }
}
