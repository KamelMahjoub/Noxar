using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public Sprite MusicMuted;
    public Sprite MusicUnMuted;

    public GameObject HUD;
    public GameObject ShopPanel;
    public GameObject Joystick;
    public GameObject JumpButton;
    public GameObject AttackButton;
    public GameObject QuitButtonPausemenu;
    public GameObject QuitButtonQuitMenu;
    public GameObject CancelButton;
    public GameObject MusicButton;

    public GameObject PauseMenu;
    public GameObject QuitMenu;

    public GameObject GameOverPanel;
    public GameObject LevelCompletePanel;

    public AudioSource BGM;
    public AudioSource GameOverMusic;

    private bool checkShop;
    private bool checkMusicMuted = false;

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
    

    public bool checkShopOpen()
    {
        if (ShopPanel.activeSelf)
            return true;
        else
            return false;
    }


    public void OnPause()
    {
        checkShop = checkShopOpen();
        HUD.SetActive(false);
        ShopPanel.SetActive(false);
        Joystick.GetComponent<Image>().enabled = false;
        JumpButton.GetComponent<Image>().enabled = false;
        AttackButton.GetComponent<Image>().enabled = false;
        PauseMenu.SetActive(true);
        BGM.Pause();
        Time.timeScale = 0f;

    }

    public void OnResume()
    {
        HUD.SetActive(true);
        if(checkShop)
            ShopPanel.SetActive(true);
        else
            ShopPanel.SetActive(false);
        Joystick.GetComponent<Image>().enabled = true;
        JumpButton.GetComponent<Image>().enabled = true;
        AttackButton.GetComponent<Image>().enabled = true;
        PauseMenu.SetActive(false);
        BGM.Play();
        Time.timeScale = 1f;
    }

    public void ShowQuitMenu()
    {
        PauseMenu.SetActive(false);
        QuitMenu.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        QuitMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void MuteMusic()
    {
        if (checkMusicMuted==false)
        {
            MusicButton.GetComponent<Image>().sprite = MusicMuted;
            checkMusicMuted = true;
            BGM.mute = true;
        }
        else
        {
            if (checkMusicMuted == true)
            {
                MusicButton.GetComponent<Image>().sprite = MusicUnMuted;
                checkMusicMuted = false;
                BGM.mute = false;
            }
        }  
    }

    public void ShowGameOverPanel()
    {
        
        HUD.SetActive(false);
        Joystick.GetComponent<Image>().enabled = false;
        JumpButton.GetComponent<Image>().enabled = false;
        AttackButton.GetComponent<Image>().enabled = false;
        GameOverPanel.SetActive(true);
        BGM.Stop();
        GameOverMusic.Play();
        Time.timeScale = 0f;
    }

    public void ShowGameLevelCompletePanel()
    {
        Time.timeScale = 0f;
        HUD.SetActive(false);
        Joystick.GetComponent<Image>().enabled = false;
        JumpButton.GetComponent<Image>().enabled = false;
        AttackButton.GetComponent<Image>().enabled = false;
        LevelCompletePanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void LoadNextLevel(int lvNumber) 
    {
        SceneManager.LoadScene("Level "+lvNumber);
        Time.timeScale = 1f;
    }





}
