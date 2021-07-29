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

    public bool Cloak { get; set; }
    public bool Ring { get; set; }
    public bool Sword { get; set; }


    private void Awake()
    {
        _instance = this;
    }

}
