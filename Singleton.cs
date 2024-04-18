using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Honestly, im not good enough at C# to know if an abstract singleton
// will work and im too lazy to figure it out. I got a biology exam later
// and im defo failing
public abstract class Singleton<T> where T  : Singleton<T>, new() 
{
    private static T _instance = new T();

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }
}
