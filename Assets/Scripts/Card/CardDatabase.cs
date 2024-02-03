using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDatabase
{
    static object lockObject = new object(); 
    private static CardDatabase instance;
    public static CardDatabase Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new CardDatabase();
            }

            return instance;
        }
    }
    public static List<CardClass> cardDatabase = new List<CardClass>();

    public CardDatabase()
    {
        cardDatabase.Add(new CardClass (0, "Hello", 0, "Say hello", SearchSprite(0)));
        cardDatabase.Add(new CardClass (1, "Attack", 1, "造成 5 點傷害", SearchSprite(1)));
        cardDatabase.Add(new CardClass (2, "Defend", 1, "獲得 5 點護甲", SearchSprite(2)));
        cardDatabase.Add(new CardClass (3, "Defend", 1, "獲得 5 點護甲", SearchSprite(3)));
    }

    /// <summary> Get the sprite by ID. </summary>
    /// <param name="id"> The card ID of sprite you want to search. </param>
    Sprite SearchSprite(int id)
    {
        return Resources.Load<Sprite>("CardPicture/" + id.ToString());
    }

    /// <summary> Get the CardClass in CardDatabase. </summary>
    /// <param name="id"> The card ID that you want to get. </param>
    public CardClass GetCardByID(int id)
    {
        return cardDatabase.Single(item => item.ID == id);
    }
}
