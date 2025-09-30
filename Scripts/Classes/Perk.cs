using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName = "RPG/Perk")]
public class Perk : ScriptableObject
{
    [Header("Meta info")]
    public string perkName;
    [TextArea] public string description;

    [Header("Requisitos")]
    public int requiredRank;   // ej: Rank mínimo en la clase
    public bool isPassive;     // si es pasivo o activo

    [Header("Efectos")]
    public float hpBonus;
    public float strBonus;
    public float agiBonus;
    public float critChanceBonus;
    public bool surviveWith1HP;   // ej: "sobrevive a 1 HP"

    // 👇 Aquí puedes meter lógica si quieres
    public void Apply(CharacterRuntime character)
    {
        character.HP += (int)hpBonus;
        character.STR += strBonus;
        character.AGI += agiBonus;
        character.LCK += critChanceBonus;

        if (surviveWith1HP)
        {
            // podrías setear un flag en character para que BattleManager lo use
        }
    }
}
