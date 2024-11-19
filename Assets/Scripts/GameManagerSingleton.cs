using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    private static GameManagerSingleton instance;
    public static GameManagerSingleton Instance
    {
        get
        {
            if (instance == null) {
                GameObject gameObject = new GameObject();
                gameObject.name = "GameManagerSingleton";
                instance = gameObject.AddComponent<GameManagerSingleton>();
                DontDestroyOnLoad(Instance.gameObject);
            }
            return instance;
        }
    }
}
