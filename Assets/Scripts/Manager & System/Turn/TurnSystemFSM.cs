using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TurnSystemStateType
{
    Run, Player, Enemy
}

[Serializable]
public class TurnSystemParameter
{
    public RunBar currentBar;
    public RunBar playerBar;
    public RunBar[] enemyBars;
    public TextMeshProUGUI turnText;
    
    public GameObject mana;
    public GameObject turnedEndButton;

    public bool isPlayerTurn, isEnemysTurn, isTurnEnd;
}

public class TurnSystemFSM : MonoBehaviour
{
    private ITurnSystemState currentState;
    private Dictionary<TurnSystemStateType, ITurnSystemState> states = new Dictionary<TurnSystemStateType, ITurnSystemState>();
    public TurnSystemParameter parameter = new TurnSystemParameter();

    void Awake()
    {
        Transform tempBar = transform.Find("PlayerRunBar");
        parameter.playerBar = new RunBar (bar:tempBar.GetComponent<Image>(),
                                pos:tempBar.GetChild(0).GetComponent<Image>(),
                                current:0,
                                speed:10,
                                maxDist:20,
                                isArrivedDist:false
                                );
        
        parameter.turnText = GameObject.Find("TurnText").GetComponent<TextMeshProUGUI>();
        parameter.turnedEndButton = GameObject.Find("EndTurnButton");
        parameter.mana = GameObject.Find("Mana");
        
        parameter.turnedEndButton.SetActive(false);
    }

    void Start()
    {
        states.Add(TurnSystemStateType.Run, new TurnSystemRunState(this));
        states.Add(TurnSystemStateType.Player, new TurnSystemPlayerState(this));

        TransitionState(TurnSystemStateType.Run);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    /// <summary> Set the next state. </summary>
    /// <param name="type">The set state type. </param>
    public void TransitionState(TurnSystemStateType type)
    {
        if(currentState != null)
            currentState.OnExit();

        currentState = states[type];
        currentState.OnEnter();
    }

    /// <summary> Get the current turn status. </summary>
    public bool GetTurnEnd()
    {
        return parameter.isTurnEnd;
    }

    /// <summary> Set if the current turn to true. </summary>
    public void SetTurnEnd()
    {
        parameter.isTurnEnd = true;
    }

    /// <summary> Set if the current turn to value. </summary>
    /// <param name="value">The set value. </param>
    public void SetTurnEnd(bool value)
    {
        parameter.isTurnEnd = value;
    }

    /// <summary> When isPlayerTurn is true, draw start 4 card. </summary>
    public IEnumerator StartTurnDraw()
    {
        Hand.Instance.SetIsDrawing(true);

        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            PlayerDeck.Instance.DrawCard(Hand.Instance.transform);
        }

        parameter.turnedEndButton.SetActive(true);
        Hand.Instance.SetIsDrawing(false);
    }

    /// <summary> End turn and throw to deck muck. </summary>
    public void EndTurnThrow()
    {
        parameter.turnedEndButton.SetActive(false);

        for(int i = 0; i < Hand.Instance.transform.childCount; i++)
        {
            GameObject tempCard = Hand.Instance.transform.GetChild(i).gameObject;

            CardClass card = tempCard.GetComponent<Card>().thisCard;
            PlayerDeckMuck.Instance.AddToMuck(card);

            Destroy(tempCard);
        }
    }

    // public void TurnEndCheck(bool unitTurn)
    // {
    //     if(parameter.turnEnd)
    //     {
    //         parameter.currentBar.Current = 0;
    //         parameter.currentBar.IsArrivedDist = false;

    //         parameter.turnText.text = "";

    //         unitTurn = false;
    //         parameter.turnEnd = false;
    //     }
    // }
}
