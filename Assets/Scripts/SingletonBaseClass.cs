﻿using UnityEngine;

public class SingletonBaseClass<T>: MonoBehaviour where T: MonoBehaviour 
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            string log = typeof(T).Name;

            if (instance != null) return instance;
            
            instance = FindObjectOfType<T>();
            if (instance == null)
            {
                Debug.LogError($"{log} not found");
            }

            return instance;
        }
    }
}