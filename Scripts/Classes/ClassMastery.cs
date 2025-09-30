using UnityEngine;

[CreateAssetMenu(fileName = "ClassMastery", menuName = "RPG/Class Mastery")]
public class ClassMastery : ScriptableObject
{
    public string className;
    [TextArea] public string description;

    [Header("Stat modifiers por rank")]
    public int[] strBonusPerRank;
    public int[] resBonusPerRank;
    public int[] agiBonusPerRank;
    public int[] lckBonusPerRank;
    public int[] vitBonusPerRank;

    [Header("Perks desbloqueables")]
    public Perk[] perks;  // Cada rank puede desbloquear 1+ perks
}
