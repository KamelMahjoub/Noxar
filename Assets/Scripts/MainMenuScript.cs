using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject OptionsPanel;
    public GameObject HelpPanel;
    public GameObject MenuPanel;
    public GameObject ReturnHelpBtn;


    public void StartGame()
    {
        SceneManager.LoadScene("Loading Screen 2");
    }


    public void OpenOptions()
    {
        MenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void OpenHelp()
    {
        MenuPanel.SetActive(false);
        HelpPanel.SetActive(true);
        ReturnHelpBtn.SetActive(true);
    }

    public void ReturnFromOptions()
    {
        MenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }

    public void ReturnFromHelp()
    {
        MenuPanel.SetActive(true);
        HelpPanel.SetActive(false);
        ReturnHelpBtn.SetActive(false);
    }




    public void QuitGame()
    {
        Application.Quit();
    }
}
