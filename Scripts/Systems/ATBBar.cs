using System.Collections;
using UnityEngine;

public class ATBBar : MonoBehaviour
{
    [Header("Refs")]
    public StatsTerminal statsTerminal;   // si está en el mismo GO, se resuelve solo

    [Header("Tuning")]
    public float agiToSpeed = 10f;        // cuántos puntos/seg por cada punto de AGI
    public float minFillSpeed = 5f;       // velocidad mínima de seguridad
    public float executeDuration = 1f;    // cuánto “parpadea” al ejecutar

    private float atbValue;               // 0..100
    private float fillSpeed;              // puntos/seg
    private bool isExecuting;             // ¡ya no público!

    void OnEnable()  { ResetState(); }    // asegura estado limpio cada vez que entras a Play
    void Awake()     { ResetState(); }

    void Start()
    {
        if (statsTerminal == null)
            statsTerminal = GetComponent<StatsTerminal>();

        float agi = (statsTerminal != null && statsTerminal.Runtime != null)
                    ? statsTerminal.Runtime.AGI : 5f;

        fillSpeed = Mathf.Max(agi * agiToSpeed, minFillSpeed);
    }

    void Update()
    {
        if (isExecuting) return;

        atbValue += fillSpeed * Time.deltaTime;
        if (atbValue >= 100f)
        {
            atbValue = 100f;
            StartCoroutine(ExecuteAction());
        }
    }

    private IEnumerator ExecuteAction()
    {
        isExecuting = true;

        // Simula “acción ejecutándose” (parpadeo/pausa)
        float t = 0f;
        while (t < executeDuration)
        {
            t += Time.deltaTime;
            yield return null;
        }

        ResetState(); // vuelve a 0 y apaga ejecución
    }

    private void ResetState()
    {
        isExecuting = false;
        atbValue = 0f;
    }

    // Debug overlay (IMGUI)
    void OnGUI()
    {
        if (statsTerminal == null) return;

        var style = new GUIStyle { fontSize = 18 };
        style.normal.textColor = isExecuting ? Color.red : Color.green;

        GUILayout.BeginArea(new Rect(10, 200, 240, 90));
        GUILayout.Label($"ATB ({statsTerminal.Runtime.AGI} AGI): {atbValue:0}", style);

        // barrita simple
        float w = 180f;
        GUI.Box(new Rect(10, 230, w, 20), "");
        GUI.Box(new Rect(10, 230, (atbValue / 100f) * w, 20), "");
        GUILayout.EndArea();
    }
}
