using System;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static List<T> GetListOfAllEnumValues<T>() where T : Enum
    {
        List<T> statList = new List<T>();
        var values = Enum.GetValues(typeof(T));
        foreach( var value in values)
        {
            statList.Add((T)value);
        }
        return statList;
    }
}
