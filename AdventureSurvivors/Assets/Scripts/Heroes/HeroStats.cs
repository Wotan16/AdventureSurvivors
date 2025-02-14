using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeroStats
{
    public List<HeroStat> stats;

    public HeroStats(StatsData statsData, MinMaxValues minMaxValues)
    {
        stats = new List<HeroStat>();
        List<HeroStatType> statTypes = Utils.GetListOfAllEnumValues<HeroStatType>();
        foreach (HeroStatType statType in statTypes)
        {
            HeroStat stat = new HeroStat(statType,
                statsData.GetStatValueOfType(statType),
                minMaxValues.GetMinValueOfType(statType),
                minMaxValues.GetMaxValueOfType(statType));
            stats.Add(stat);
        }
    }

    public HeroStat GetStatOfType(HeroStatType statType)
    {
        foreach (HeroStat stat in stats)
        {
            if(stat.type == statType)
                return stat;
        }
        return null;
    }
}
