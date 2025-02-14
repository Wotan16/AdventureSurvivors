using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "Scriptable Objects/HeroData")]
public class HeroData : ScriptableObject
{
    public string heroName;
    public Sprite heroIcon;
    public HeroBase prefab;
    //List of skill data
    
}
