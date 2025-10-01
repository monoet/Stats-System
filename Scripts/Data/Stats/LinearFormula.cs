using UnityEngine;

[CreateAssetMenu(menuName = "JRPG/Stat Formula/Linear")]
public class LinearFormula : StatFormula
{
    public override int MaxHP(CoreStats s) 
        => s.BaseHP + (int)(s.BaseVIT * 10);

    public override int MaxMP(CoreStats s) 
        => s.BaseMP + (int)(s.BaseRES * 5);

    public override float STR(CoreStats s) 
        => s.BaseSTR + s.BonusSTR;
    public override float RES(CoreStats s) 
        => s.BaseRES + s.BonusRES;
    public override float AGI(CoreStats s) 
        => s.BaseAGI + s.BonusAGI;
    public override float LCK(CoreStats s) 
        => s.BaseLCK + s.BonusLCK;
    public override float VIT(CoreStats s) 
        => s.BaseVIT + s.BonusVIT;
}
