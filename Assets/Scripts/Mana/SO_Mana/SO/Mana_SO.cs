using UnityEngine;

[CreateAssetMenu(fileName = "Mana Data", menuName = "Mana Stats/Mana Data")]
public class Mana_SO : ScriptableObject
{
    [Header("Stats Info")]
    public int maxMana;
    public int currentMana;

    void OnEnable()
    {
        currentMana = 0;
    }
}
