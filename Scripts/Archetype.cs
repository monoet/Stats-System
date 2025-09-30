using UnityEngine;

[CreateAssetMenu(fileName = "Archetype", menuName = "RPG/Character Archetype")]
public class Archetype : ScriptableObject 
{
    [Header("Nivel 1 (stats base)")]
    [HideInInspector] public int level = 1;
    public int baseHP = 100;
    public int baseMP = 20;

    public int STR = 5;
    public int RES = 5;   // Resonancia/Magia
    public int AGI = 5;   // Action speed
    public int LCK = 5;
    public int VIT = 5;

    [Header("Crecimiento por nivel (identidad)")]
    public float strPerLevel = 1f;
    public float resPerLevel = 1.5f;
    public float agiPerLevel = 3f;
    public float lckPerLevel = 2f;
    public float vitPerLevel = 2f;
}
