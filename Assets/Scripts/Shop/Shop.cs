
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private Player _player;
    public GameObject ShopPanel;
    public Text coinText;
    public Text panelText;
    public GameObject buttonBuy;

    public GameObject JumpPanelScript;
    private JumpPanel JumpPanelVar;


    private void Awake()
    {
        JumpPanelVar = JumpPanelScript.GetComponent<JumpPanel>();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = collision.GetComponent<Player>();

            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.Coins);
            }
            ShopPanel.SetActive(true);
            coinText.text = "" + _player.Coins;
            Time.timeScale = 0f;
        }
    }


     public virtual void ExitMenu()
     {
      ShopPanel.SetActive(false);
      Time.timeScale = 1f;
     }


    public virtual bool CheckItemPurchased(int ItemID)
    {
        switch(ItemID)
        {
            case 1:
                if (GameManager.Instance.Item1 == true)
                    return true;
                break;
            case 2:
                if (GameManager.Instance.Item2 == true)
                    return true;
                break;
            case 3:
                if (GameManager.Instance.Item3 == true)
                    return true;
                break;
        }
        return false;
    }



    public virtual void AwardItem(int ItemID)
    {
        switch (ItemID)
        {
            case 1:
                GameManager.Instance.Item1 = true;        
                break;
            case 2:
                GameManager.Instance.Item1 = true;
                break;
            case 3:
                GameManager.Instance.Item1 = true;
                break;
        }
    }

    public int getItemPrice(int ItemID)
    {
        switch (ItemID)
        {
            case 1:

                return JumpPanelVar._itemPrice;
                
            case 2:
                return 1;
                
            case 3:
                return 2;
                
            default:
                return 99999999;  
        }
    }

    public String getItemName(int ItemID)
    {
        switch (ItemID)
        {
            case 1:
                return JumpPanelVar._itemName;
               
            case 2:
                return "1";
                
            case 3:
                return "2";
                
            default:
                return "99999999";
        }
    }

   public String GetPanelText(int ItemID)
    {
        if (CheckItemPurchased(ItemID))
        {
            buttonBuy.SetActive(false);
            if (ItemID == 1)
                return "You have already purchased this item.Your jump power has been increased!";
            if (ItemID == 2)
                return "You have already purchased this item.Your speed has been increased!";
            if (ItemID == 3)
                return "You have already purchased this item.Your attack power have been increased!";
        }
        else
        {
            buttonBuy.SetActive(true);
            return "Would you like to purchase a " + getItemName(ItemID) + " for " + getItemPrice(ItemID) + " Coins?";
        }

        return "ERROR" + ItemID;

    }


    public virtual void BuyItem(int ItemID)
    {
        int price = getItemPrice(ItemID);
        Debug.Log(price);
        Debug.Log(ItemID);

        if (CheckItemPurchased(ItemID) == false)
        {
            if(_player.Coins >= price)
            {
                AwardItem(ItemID);
                _player.SubstractCoins(price);
                if (CheckItemPurchased(ItemID))
                {
                    buttonBuy.SetActive(false);
                    if (ItemID == 1)
                       panelText.text = "Congratulations! You can now jump higher!";
                    if (ItemID == 2)
                        panelText.text = "Congratulations! You can move faster!";
                    if (ItemID == 3)
                        panelText.text = "Congratulations! You can now hit harder";
                }

                buttonBuy.SetActive(false);
            }
            else
            {
                panelText.text = "You don't have enough coins to make this purchase!";
                buttonBuy.SetActive(false);
            }
        }
        
    }










 
}








