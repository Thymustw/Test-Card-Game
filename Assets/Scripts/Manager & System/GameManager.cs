using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    bool back = true;
    //PlayerDeck playerDeck;
    // Start is called before the first frame update
    public bool GetBack() { return back; }
    public void SetBack(bool value) { back = value; }

    //public void RegisterPlayerDeckToGM(PlayerDeck value) { playerDeck = value; }

    void Start()
    {
        
    }
}
