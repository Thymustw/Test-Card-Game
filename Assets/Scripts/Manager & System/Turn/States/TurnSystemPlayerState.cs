using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystemPlayerState : ITurnSystemState
{
    private TurnSystemFSM Manager;
    private TurnSystemParameter Parameter;

    ManaStats manaStats;
    
    public TurnSystemPlayerState(TurnSystemFSM manager)
    {
        Manager = manager;
        Parameter = manager.parameter;
    }
    public void OnEnter()
    {
        Parameter.turnText.text = "你的回合";
        Parameter.isPlayerTurn = true;

        //Parameter.turnedEndButton.SetActive(true);

        // Set the current mana.
        manaStats = Parameter.mana.GetComponent<ManaStats>();
        manaStats.SetCurrentMana(manaStats.GetMaxMana());
        
        Manager.StartCoroutine(Manager.StartTurnDraw());
    }

    public void OnExit()
    {
        Parameter.currentBar.Current = 0;
        Parameter.currentBar.IsArrivedDist = false;

        Parameter.turnText.text = "";

        //Parameter.turnedEndButton.SetActive(false);

        Manager.EndTurnThrow();

        Manager.SetTurnEnd(false);
    }

    public void OnUpdate()
    {
        if(Manager.GetTurnEnd())
        {
            Manager.TransitionState(TurnSystemStateType.Run);
        }
    }
}
