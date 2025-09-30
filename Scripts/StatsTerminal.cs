using UnityEngine;

public class StatsTerminal : MonoBehaviour
{
    public Archetype archetype;  // referencia al Archetype
    public int level = 1;

    public CharacterRuntime Runtime { get; private set; }

    void Start()
    {
        Runtime = new CharacterRuntime();
        Runtime.archetype = archetype;
        Runtime.currentLevel = level;
        Runtime.Recalc();
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 16;
        style.normal.textColor = Color.green;

        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        GUILayout.Label($"== {archetype.name} ==", style);
        GUILayout.Label($"Level: {Runtime.currentLevel}", style);
        GUILayout.Label($"HP: {Runtime.HP}", style);
        GUILayout.Label($"MP: {Runtime.MP}", style);
        GUILayout.Label($"STR: {Runtime.STR}", style);
        GUILayout.Label($"RES: {Runtime.RES}", style);
        GUILayout.Label($"AGI: {Runtime.AGI}", style);
        GUILayout.Label($"LCK: {Runtime.LCK}", style);
        GUILayout.Label($"VIT: {Runtime.VIT}", style);
        GUILayout.EndArea();
    }
}
