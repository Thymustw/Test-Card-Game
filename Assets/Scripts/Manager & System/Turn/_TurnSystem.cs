using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    RunBar playerBar;
    // Image playerBar, playerPos;
    // float playerCurrent = 0;
    bool isPlayerTurn, isPlayerStartDraw;

    RunBar currentBar;
    RunBar[] enemyBars;
    bool isEnemysTurn;

    public TextMeshProUGUI turnText;
    bool turnEnd;
    void Awake()
    {
        Transform tempBar = transform.Find("PlayerRunBar");
        playerBar = new RunBar (bar:tempBar.GetComponent<Image>(),
                                pos:tempBar.GetChild(0).GetComponent<Image>(),
                                current:0,
                                speed:10,
                                maxDist:20,
                                isArrivedDist:false
                                );
        turnText.text = "";
    }

    void FixedUpdate()
    {
        // Turn check time;
        if(playerBar.IsArrivedDist)
        {
            currentBar = playerBar;
            turnText.text = "你的回合";
            isPlayerTurn = true;
        }
        //else
        //{
        //    foreach(RunBar tempRunBar in enemyBars)
        //    {
        //        if (tempRunBar.IsArrivedDist)
        //        {
        //            isEnemysTurn = true;
        //            currentEnemyBar = tempRunBar;
        //            return;
        //        }
        //    }
        //}

        // If turn check time all false, then get in run time.
        // Finished then go to turn check time.
        if (!isPlayerTurn && !isEnemysTurn)
        {
            playerBar.Run();
        }

        // If turn check time has a true, then get in round time.
        // Finished then go to turn check time.
        if(isPlayerTurn)
        {
            if(!isPlayerStartDraw)
            {
                isPlayerStartDraw = true;
                StartCoroutine(PlayerDeck.Instance.StartTurnDraw());
            }
            TurnEndCheck(isPlayerTurn);
        }
        else if (isEnemysTurn)
        {
            TurnEndCheck(isEnemysTurn);
        }
    }

    public void SetTurnEnd()
    {
        turnEnd = true;
    }

    public void SetTurnEnd(bool value)
    {
        turnEnd = value;
    }

    void TurnEndCheck(bool unitTurn)
    {
        if(turnEnd)
        {
            currentBar.Current = 0;
            currentBar.IsArrivedDist = false;

            turnText.text = "";

            unitTurn = false;
            turnEnd = false;
        }
    }
}
