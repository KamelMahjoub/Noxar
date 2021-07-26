using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null!");
            }
            return _instance;
        }
    }

   // public Text playerCoinCountText;

   // public Image selectionImg;

    public Text CoinCountText;

    public Image[] Healthbars;



    private void Awake()
    {
        _instance = this;
    }

    public void UpdateCoinCount(int count)
    {
        CoinCountText.text = "" + count + " X";
    }


    public void UpdateLives(int livesRemaning)
    {
        //loop through lives 
        for (int i = 0; i <= livesRemaning; i++)
        {
            //do nothing till we hit the max
            if (i == livesRemaning)
            {
                //hide this one
                Healthbars[i].enabled = false;
            }

        }
        //i == lives remaning 
        // hide that one
    }
}
