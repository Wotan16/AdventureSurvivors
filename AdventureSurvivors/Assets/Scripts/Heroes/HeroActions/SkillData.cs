using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillStats", menuName = "Scriptable Objects/SkillStats")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public Sprite Icon;
    public List<SkillStat> skillStats;
    public HeroSkillBase prefab;
}

[Serializable]
public class SkillStat
{
    [Header("Base")]
    public SkillStatType skillStatType;
    public double flatValue;
    public double flatValuePerLevel;

    [Serializable]
    public class StatModifier
    {
        public HeroStatType heroStatType;
        public double baseModValue;
        public double modBonusPerLevel;
    }

    public List<StatModifier> baseModifiers;

    public double GetTotalValue(HeroStats stats, int level)
    {
        double totalValue = flatValue + (flatValuePerLevel * (level - 1));
        foreach (StatModifier modifier in baseModifiers)
        {
            HeroStat stat = stats.GetStatOfType(modifier.heroStatType);
            totalValue += (modifier.baseModValue + (modifier.modBonusPerLevel * (level - 1))) * stat.Value;
        }
        return totalValue;
    }
}