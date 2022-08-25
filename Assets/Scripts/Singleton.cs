using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instnace = null;
    public static T Instance
    {
        get 
        {
            if (instnace == null)
            {
                instnace = FindObjectOfType<T>();
                if (instnace == null)
                {
                    instnace = new GameObject().AddComponent<T>();
                }
            }
            return instnace;
        }
    }
}
