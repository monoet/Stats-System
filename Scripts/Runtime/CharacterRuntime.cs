using UnityEngine;

public class CharacterRuntime : MonoBehaviour
{
    [Header("Core stats base + bonus")]
    [SerializeField] private CoreStats core;

    [Header("Stat Formula (Strategy)")]
    [SerializeField] private StatFormula statFormula;

    // === Propiedades calculadas ===
    public int HP { get; private set; }
    public int MP { get; private set; }
    public float STR { get; private set; }
    public float RES { get; private set; }
    public float AGI { get; private set; }
    public float LCK { get; private set; }
    public float VIT { get; private set; }

    /// <summary>
    /// Recalcula todos los valores finales usando la fórmula seleccionada.
    /// </summary>
    public void Recalc()
    {
        if (statFormula == null)
        {
            Debug.LogWarning("No StatFormula assigned!");
            return;
        }

        HP  = statFormula.MaxHP(core);
        MP  = statFormula.MaxMP(core);
        STR = statFormula.STR(core);
        RES = statFormula.RES(core);
        AGI = statFormula.AGI(core);
        LCK = statFormula.LCK(core);
        VIT = statFormula.VIT(core);
    }

    // ===== Métodos controlados para modificar bonus =====
    public void AddBonus(float str = 0, float res = 0, float agi = 0, float lck = 0, float vit = 0)
    {
        core.BonusSTR += str;
        core.BonusRES += res;
        core.BonusAGI += agi;
        core.BonusLCK += lck;
        core.BonusVIT += vit;
        Recalc();
    }

    public void RemoveBonus(float str = 0, float res = 0, float agi = 0, float lck = 0, float vit = 0)
    {
        core.BonusSTR -= str;
        core.BonusRES -= res;
        core.BonusAGI -= agi;
        core.BonusLCK -= lck;
        core.BonusVIT -= vit;
        Recalc();
    }

    // === Exposición controlada del struct (solo lectura) ===
    public CoreStats GetCoreStats() => core;

    // === Helpers opcionales ===
    public int Level => core.Level;
    public int BaseHP => core.BaseHP;
    public float BaseSTR => core.BaseSTR;
}
