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



    public Text CoinCountText;

    public Image[] Healthbars;

    public GameObject inventorySlot1;
    public GameObject inventorySlot2;
    public GameObject inventorySlot3;
    public Sprite CapeSprite;
    public Sprite RingSprite;
    public Sprite SwordSprite;

    public GameObject HUD;
    public GameObject ShopPanel;
    public GameObject ControlUI;
    public GameObject PauseMenu;


    private void Start()
    {
    }
    private void Awake()
    {
        _instance = this;     
    }

   

    public void UpdateCoinCount(int count)
    {
        CoinCountText.text = "" + count;
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

    public void UpdateInventoryOnAdd(int ItemID)
    {
        switch(ItemID)
        {
            case 1:
                if (inventorySlot1.activeSelf == false)
                {
                    inventorySlot1.GetComponent<Image>().sprite = CapeSprite;
                    inventorySlot1.SetActive(true);
                }
                else
                if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf == false))
                {
                    inventorySlot2.GetComponent<Image>().sprite = CapeSprite;
                    inventorySlot2.SetActive(true);
                }
                else
                if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf) && (inventorySlot3.activeSelf == false))
                {
                    inventorySlot3.GetComponent<Image>().sprite = CapeSprite;
                    inventorySlot3.SetActive(true);
                }
                break;
            case 2:
                if (inventorySlot1.activeSelf == false)
                {
                    inventorySlot1.GetComponent<Image>().sprite = RingSprite;
                    inventorySlot1.SetActive(true);
                }
                else
               if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf == false))
                {
                    inventorySlot2.GetComponent<Image>().sprite = RingSprite;
                    inventorySlot2.SetActive(true);
                }
                else
               if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf) && (inventorySlot3.activeSelf == false))
                {
                    inventorySlot3.GetComponent<Image>().sprite = RingSprite;
                    inventorySlot3.SetActive(true);
                }
                break;
            case 3:
                if (inventorySlot1.activeSelf == false)
                {
                    inventorySlot1.GetComponent<Image>().sprite = SwordSprite;
                    inventorySlot1.SetActive(true);
                }
                else
               if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf == false))
                {
                    inventorySlot2.GetComponent<Image>().sprite = SwordSprite;
                    inventorySlot2.SetActive(true);
                }
                else
               if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf) && (inventorySlot3.activeSelf == false))
                {
                    inventorySlot3.GetComponent<Image>().sprite = SwordSprite;
                    inventorySlot3.SetActive(true);
                }
                break;
            default:
                Debug.Log("ItemID" + ItemID);
                break;
        }
    }

    public void UpdateInventory()
    {

        if (GameManager.Instance.Cloak)
        {
            if (inventorySlot1.activeSelf == false)
            {
                inventorySlot1.GetComponent<Image>().sprite = CapeSprite;
                inventorySlot1.SetActive(true);
            }
            else
            if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf == false))
            {
                inventorySlot2.GetComponent<Image>().sprite = CapeSprite;
                inventorySlot2.SetActive(true);
            }
            else
            if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf) && (inventorySlot3.activeSelf == false))
            {
                inventorySlot3.GetComponent<Image>().sprite = CapeSprite;
                inventorySlot3.SetActive(true);
            }
        }

        if (GameManager.Instance.Ring)
        {
            if (inventorySlot1.activeSelf == false)
            {
                inventorySlot1.GetComponent<Image>().sprite = RingSprite;
                inventorySlot1.SetActive(true);
            }
            else
           if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf == false))
            {
                inventorySlot2.GetComponent<Image>().sprite = RingSprite;
                inventorySlot2.SetActive(true);
            }
            else
           if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf) && (inventorySlot3.activeSelf == false))
            {
                inventorySlot3.GetComponent<Image>().sprite = RingSprite;
                inventorySlot3.SetActive(true);
            }

        }
        if(GameManager.Instance.Sword)
        {
                if (inventorySlot1.activeSelf == false)
                {
                    inventorySlot1.GetComponent<Image>().sprite = SwordSprite;
                    inventorySlot1.SetActive(true);
                }
                else
               if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf == false))
                {
                    inventorySlot2.GetComponent<Image>().sprite = SwordSprite;
                    inventorySlot2.SetActive(true);
                }
                else
               if ((inventorySlot1.activeSelf) && (inventorySlot2.activeSelf) && (inventorySlot3.activeSelf == false))
                {
                    inventorySlot3.GetComponent<Image>().sprite = SwordSprite;
                    inventorySlot3.SetActive(true);
                }
        }
    }
    

    public void OnPause()
    {
        HUD.SetActive(false);
        ShopPanel.SetActive(false);
        ControlUI.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }


}
