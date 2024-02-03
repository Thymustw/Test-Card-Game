using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClass
{
    public int ID, Cost;
    public string Name, Description;
    public Sprite ImageSprite;
    public CardClass(int id, string name, int cost, string description, Sprite sprite)
    {
        ID = id;
        Name = name;
        Cost = cost;
        Description = description;

        ImageSprite = sprite;
    }
}
