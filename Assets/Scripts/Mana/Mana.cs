using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mana : MonoBehaviour
{
    ManaStats manaStats;
    TextMeshProUGUI manaText;
    
    void Start()
    {
        manaStats = GetComponent<ManaStats>();
        manaText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        manaText.text = manaStats.GetCurrentMana() + "/" + manaStats.GetMaxMana();
    }
}
