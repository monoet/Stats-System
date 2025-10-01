using UnityEngine;

[System.Serializable]
public struct CoreStats
{
    public int Level;

    [Header("Stats base")]
    public int BaseHP;
    public int BaseMP;
    public float BaseSTR;
    public float BaseRES;
    public float BaseAGI;
    public float BaseLCK;
    public float BaseVIT;

    [Header("Bonuses (por perks/equipo)")]
    public float BonusSTR;
    public float BonusRES;
    public float BonusAGI;
    public float BonusLCK;
    public float BonusVIT;
}

