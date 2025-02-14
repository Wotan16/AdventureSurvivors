using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class StatsData 
{
    public List<StatValuePair> baseValuesList;

    public double GetStatValueOfType(HeroStatType statType)
    {
        foreach (StatValuePair pair in baseValuesList)
        {
            if (pair.statType == statType)
                return pair.value;
        }
        return 0;
    }

    public void OnValidate()
    {
        if (baseValuesList == null)
        {
            baseValuesList = new List<StatValuePair>();
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
        while(baseValuesList.Count != allStatTypes.Count)
        {
            if(baseValuesList.Count > allStatTypes.Count)
                baseValuesList.Remove(baseValuesList.Last());
            else
                baseValuesList.Add(new StatValuePair(allStatTypes.First(), 0));
        }
    }

    private bool ContainsStatType(HeroStatType type)
    {
        foreach(StatValuePair pair in baseValuesList)
        {
            if(pair.statType == type)
                return true;
        }
        return false;
    }

    [Serializable]
    public class StatValuePair
    {
        public HeroStatType statType;
        public double value;

        public StatValuePair(HeroStatType statType, double value)
        {
            this.statType = statType;
            this.value = value;
        }
    }
}
