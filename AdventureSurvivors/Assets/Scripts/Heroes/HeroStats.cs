using System;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    //public HeroStat damage { get; private set; }
    //public HeroStat attackSpeed { get; private set; }

    //private void Awake()
    //{
    //    damage = new HeroStat(10, 0, 10000);
    //    attackSpeed = new HeroStat(1, 0.1, 10);
    //}
}

//public class HeroStat<TStatValue> where TStatValue : IComparable

//{
//    public TStatValue baseValue;
//    public TStatValue maxValue;
//    public TStatValue modifier;
//    public float multiplier = 1f;

//    public TStatValue Value;

//    public HeroStat(TStatValue baseValue, TStatValue maxValue, TStatValue modifier, float multiplier = 1f)
//    {
//        this.baseValue = baseValue;
//        this.maxValue = maxValue;
//        this.modifier = modifier;
//        this.multiplier = multiplier;
//    }

//    public void SetModifier(TStatValue newValue)
//    {
//        modifier = newValue;
//        UpdateCurrentValue();
//    }

//    public void AddModifier(TStatValue addValue)
//    {
//        modifier = Add(modifier, addValue);
//        UpdateCurrentValue();
//    }

//    public void SetMultipier(float value)
//    {
//        multiplier = value;
//        UpdateCurrentValue();
//    }

//    public void AddMultipier(float value)
//    {
//        multiplier += value;
//        UpdateCurrentValue();
//    }

//    private void UpdateCurrentValue()
//    {
//        TStatValue newValue = Add(baseValue, modifier);
//        newValue = Multiply(newValue, multiplier);
//        Value = modifier.CompareTo(maxValue) > 0 ? maxValue : modifier;
//    }

//    private static TStatValue Add(TStatValue value1, TStatValue value2)
//    {
//        dynamic dynamic1 = value1;
//        dynamic dynamic2 = value2;
//        return dynamic1 + dynamic2;
//    }

//    private static TStatValue Multiply(TStatValue value1, float multiplier)
//    {
//        dynamic dynamic1 = value1;
//        return dynamic1 * multiplier;
//    }
//}
