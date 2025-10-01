using UnityEngine;
[CreateAssetMenu(menuName = "JRPG/Archetype")]
public class Archetype : ScriptableObject
{
    public string archetypeName; [Header("Stats base")]
    public int baseHP;
    public int baseMP;
    public float baseSTR;
    public float baseRES;
    public float baseAGI;
    public float baseLCK;
    public float baseVIT;
    [Header("Progresión")]
    public AnimationCurve hpGrowth;
    public AnimationCurve mpGrowth;
    public AnimationCurve strGrowth;
    public AnimationCurve resGrowth;
    public AnimationCurve agiGrowth;
    public AnimationCurve lckGrowth;
    public AnimationCurve vitGrowth;
}
