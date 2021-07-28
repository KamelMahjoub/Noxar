using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            //if its null , it'll break the game
            if (_instance == null) 
            {
                Debug.Log("Game Manager is Null!");
            }
            return _instance;
        }
    }

    public bool Item1 { get; set; }
    public bool Item2 { get; set; }
    public bool Item3 { get; set; }


    private void Awake()
    {
        _instance = this;
    }

}
