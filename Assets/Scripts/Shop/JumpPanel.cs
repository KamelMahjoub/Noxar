using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpPanel : ShopV3
{

    [HideInInspector]
    public String _itemName { get; set; }
    [HideInInspector]
    public int _itemPrice { get; set; }
    [HideInInspector]
    public int _itemID { get; set; }

    public Button purchaseButton;

    public void Start()
    {
        _itemName = "Cape of flight";
        _itemPrice = 15;
        _itemID = 1;
        Button b = purchaseButton.GetComponent<Button>();
        b.onClick.AddListener(() => BuyItem(_itemID));
    }

  
    public override void OnTriggerEnter2D(Collider2D collision)
    {
       panelText.text = base.GetPanelText(_itemID);
        base.OnTriggerEnter2D(collision);
        

    }

    public override void ExitMenu()
    {
        base.ExitMenu();
    }


    public override void BuyItem(int ItemID)
    {
        base.BuyItem(_itemID);
    }



  

   




}
