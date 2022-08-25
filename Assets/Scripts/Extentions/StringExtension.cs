using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtension
{
    public static void Dump<T>(this T s)
    {
        Debug.Log(s.ToString());        
    }
}
