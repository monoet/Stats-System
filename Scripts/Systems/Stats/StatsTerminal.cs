using UnityEngine;

public class StatsTerminal : MonoBehaviour
{
    [SerializeField] private CharacterRuntime crt;

    void Start()
    {
        if (crt == null) crt = GetComponent<CharacterRuntime>();

        PrintStats();
    }

    public void PrintStats()
    {
        CoreStats c = crt.GetCoreStats();

        Debug.Log($"Level: {c.Level}");
        Debug.Log($"BaseHP: {c.BaseHP} | HP (final): {crt.HP}");
        Debug.Log($"BaseSTR: {c.BaseSTR} | STR (final): {crt.STR}");
        Debug.Log($"BaseRES: {c.BaseRES} | RES (final): {crt.RES}");
        Debug.Log($"BaseAGI: {c.BaseAGI} | AGI (final): {crt.AGI}");
        Debug.Log($"BaseLCK: {c.BaseLCK} | LCK (final): {crt.LCK}");
        Debug.Log($"BaseVIT: {c.BaseVIT} | VIT (final): {crt.VIT}");
    }
}
