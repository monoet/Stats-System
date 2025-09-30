using System.Collections.Generic;

public class CharacterRuntime
{
    public Archetype archetype;
    public int currentLevel;

    // Equipo
    public Equipment head;
    public Equipment chest;
    public Equipment legs;
    public Equipment weapon;
    public Equipment accessory;

    // Progresión
    public List<ClassProgress> classes = new();  
    public List<Perk> activePerks = new();        

    // Stats calculados
    public int HP;
    public int MP;
    public float STR, RES, AGI, LCK, VIT;

    public void Recalc()
    {
        int steps = currentLevel - 1;

        // Stats base del Archetype
        STR = archetype.STR + steps * archetype.strPerLevel;
        RES = archetype.RES + steps * archetype.resPerLevel;
        AGI = archetype.AGI + steps * archetype.agiPerLevel;
        LCK = archetype.LCK + steps * archetype.lckPerLevel;
        VIT = archetype.VIT + steps * archetype.vitPerLevel;

        // HP/MP derivados
        HP = archetype.baseHP + (int)(VIT * 10);
        MP = archetype.baseMP + (int)(RES * 5);

        // Modificadores de clases
        foreach (var c in classes)
        {
            var mastery = c.mastery;
            int rank = c.rank;

            if (rank > 0 && rank <= mastery.strBonusPerRank.Length)
            {
                STR += mastery.strBonusPerRank[rank - 1];
                RES += mastery.resBonusPerRank[rank - 1];
                AGI += mastery.agiBonusPerRank[rank - 1];
                LCK += mastery.lckBonusPerRank[rank - 1];
                VIT += mastery.vitBonusPerRank[rank - 1];
            }

            // perks por rango
            foreach (var perk in mastery.perks)
            {
                if (perk.requiredRank <= rank && !activePerks.Contains(perk))
                    activePerks.Add(perk);
            }
        }

        // Revisa todos los slots equipados
        if (head != null) ApplyEquipment(head);
        if (chest != null) ApplyEquipment(chest);
        if (legs != null) ApplyEquipment(legs);
        if (weapon != null) ApplyEquipment(weapon);
        if (accessory != null) ApplyEquipment(accessory);
    }

    private void ApplyEquipment(Equipment eq)
    {
        STR += eq.strMod;
        RES += eq.resMod;
        AGI += eq.agiMod;
        LCK += eq.lckMod;
        VIT += eq.vitMod;
    }
}

[System.Serializable]
public class ClassProgress
{
    public ClassMastery mastery;
    public int rank;
}