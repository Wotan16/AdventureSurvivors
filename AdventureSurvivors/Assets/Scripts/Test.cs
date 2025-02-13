using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<HeroData> dataList;

    private void Start()
    {
        foreach(var data in dataList)
        {
            PlayerCharacters.Instance.AddHero(data);
        }
    }
}
