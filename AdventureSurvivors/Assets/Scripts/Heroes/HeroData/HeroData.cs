using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "Scriptable Objects/HeroData")]
public class HeroData : ScriptableObject
{
    public string heroName;
    public Sprite heroIcon;
    public HeroBase prefab;
    public HeroRank rank;
    public StatsData statsData;

    //List of skill data

    private void OnValidate()
    {
        statsData.OnValidate();
    }
}
