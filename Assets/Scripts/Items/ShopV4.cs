
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopV4 : MonoBehaviour
{
    private Player _player;
    public GameObject ShopPanel;
    public Text coinText;
    public Text panelText;
    public GameObject buttonBuy;
    public GameObject AttackPanelScript;
    private AttackPanel AttackPanelVar;



    private void Awake()
    {
        AttackPanelVar = AttackPanelScript.GetComponent<AttackPanel>();

    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = collision.GetComponent<Player>();

            if (_player != null)
            {
                ShopPanel.SetActive(true);
                Time.timeScale = 0f;
            }

        }
    }


    public virtual void ExitMenu()
    {
        ShopPanel.SetActive(false);
        Time.timeScale = 1f;
    }


    public virtual bool CheckItemPurchased(int ItemID)
    {
        switch (ItemID)
        {
            case 3:
                if (GameManager.Instance.Sword == true)
                    return true;
                break;
        }
        return false;
    }



    public virtual void AwardItem(int ItemID)
    {
        switch (ItemID)
        {
            case 3:
                GameManager.Instance.Sword = true;
                UIManager.Instance.UpdateInventoryOnAdd(ItemID);
                break;
        }
    }

    public int getItemPrice(int ItemID)
    {
        switch (ItemID)
        {
            

            case 3:
                return AttackPanelVar._itemPrice;

            default:
                return 99999999;
        }
    }

    public String getItemName(int ItemID)
    {
        switch (ItemID)
        {
            
            case 3:
                return AttackPanelVar._itemName;

            default:
                return "99999999";
        }
    }

    public String GetPanelText(int ItemID)
    {

        if (CheckItemPurchased(ItemID))
        {
            buttonBuy.SetActive(false);
            if (ItemID == 3)
                return "You have already purchased this item.Your attack power have been increased!";
        }
        else
        {
            buttonBuy.SetActive(true);
            return "Would you like to acquire the " + getItemName(ItemID) + " for " + getItemPrice(ItemID) + " Coins?";
        }

        return "ERROR" + ItemID;

    }


    public virtual void BuyItem(int ItemID)
    {

        int price = getItemPrice(ItemID);

        if (CheckItemPurchased(ItemID) == false)
        {
            if (_player.Coins >= price)
            {
                AwardItem(ItemID);
                _player.SubstractCoins(price);
                if (CheckItemPurchased(ItemID))
                {
                    buttonBuy.SetActive(false);
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








