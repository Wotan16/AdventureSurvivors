using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static StatsData;

[CreateAssetMenu(fileName = "BaseStatValues", menuName = "Scriptable Objects/BaseStatValues")]
public class MinMaxValues : ScriptableObject
{
    public List<ValuesContainer> baseValuesList;

    public double GetMinValueOfType(HeroStatType statType)
    {
        foreach (ValuesContainer pair in baseValuesList)
        {
            if (pair.statType == statType)
                return pair.minValue;
        }
        return 0;
    }

    public double GetMaxValueOfType(HeroStatType statType)
    {
        foreach (ValuesContainer minMaxValues in baseValuesList)
        {
            if (minMaxValues.statType == statType)
                return minMaxValues.maxValue;
        }
        return 0;
    }

    public void OnValidate()
    {
        if (baseValuesList == null)
        {
            baseValuesList = new List<ValuesContainer>();
        }

        List<HeroStatType> allStatTypes = Utils.GetListOfAllEnumValues<HeroStatType>();
        ValidateNumberOfStats(allStatTypes);
        RemoveDuplicateTypes(allStatTypes);
    }

    private void RemoveDuplicateTypes(List<HeroStatType> allStatTypes)
    {
        for (int i = 0; i < allStatTypes.Count; i++)
        {
            if (baseValuesList[i].statType != allStatTypes[i])
            {
                baseValuesList[i].statType = allStatTypes[i];
            }
        }
    }

    private void ValidateNumberOfStats(List<HeroStatType> allStatTypes)
    {
        while (baseValuesList.Count != allStatTypes.Count)
        {
            if (baseValuesList.Count > allStatTypes.Count)
                baseValuesList.Remove(baseValuesList.Last());
            else
                baseValuesList.Add(new ValuesContainer(allStatTypes.First(), 0, 0));
        }
    }

    [Serializable]
    public class ValuesContainer
    {
        public HeroStatType statType;
        public double minValue;
        public double maxValue;

        public ValuesContainer(HeroStatType statType, double minValue, double maxValue)
        {
            this.statType = statType;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
    }
}
