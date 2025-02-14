using System;
using UnityEngine;

[Serializable]
public class HeroStat
{
    public event Action OnValueChanged;

    public HeroStatType type;
    public double baseValue;
    public double minValue;
    public double maxValue;
    public double modifier;
    public double multiplier = 1f;

    public double Value;
    public int ValueInt { get { return (int)Value; } }

    public HeroStat(HeroStatType type, double baseValue, double minValue, double maxValue, double modifier = 0, double multiplier = 1f)
    {
        this.type = type;
        this.baseValue = baseValue;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.modifier = modifier;
        this.multiplier = multiplier;
        UpdateCurrentValue();
    }

    public void SetModifier(double newValue)
    {
        modifier = newValue;
        UpdateCurrentValue();
    }

    public void AddModifier(double addValue)
    {
        modifier += addValue;
        UpdateCurrentValue();
    }

    public void SetMultipier(float newValue)
    {
        multiplier = newValue;
        UpdateCurrentValue();
    }

    public void AddMultipier(float addValue)
    {
        multiplier += addValue;
        UpdateCurrentValue();
    }

    private void UpdateCurrentValue()
    {
        double newValue = baseValue + modifier;
        newValue *= multiplier;
        Value = Math.Clamp(newValue, minValue, maxValue);
        OnValueChanged?.Invoke();
    }
}
