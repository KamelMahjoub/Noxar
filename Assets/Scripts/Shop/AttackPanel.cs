using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPanel : ShopV4
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
        _itemName = "Sword Of Calamity";
        _itemPrice = 50;
        _itemID = 3;
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
