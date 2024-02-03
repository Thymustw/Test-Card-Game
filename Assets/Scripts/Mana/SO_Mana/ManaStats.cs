using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ManaStats : MonoBehaviour
{
    public Mana_SO manaData;
    
    /// <summary> Get the max mana's value. </summary>
    public int GetMaxMana()
    {
        if(manaData != null)
            return manaData.maxMana;
        else return 0;
    }

    /// <summary> Set the max mana's value. </summary>
    /// <param name="type">The set max mana's value. </param>
    public void SetMaxMana(int value)
    {
        if(manaData != null)
            manaData.maxMana = value;
    }


    /// <summary> Get the current mana's value. </summary>
    public int GetCurrentMana()
    {
        if(manaData != null)
            return manaData.currentMana;
        else return 0;
    }

    /// <summary> Set the current mana's value. </summary>
    /// <param name="type">The set current mana's value. </param>
    public void SetCurrentMana(int value)
    {
        if(manaData != null)
            manaData.currentMana = value;
    }
}
