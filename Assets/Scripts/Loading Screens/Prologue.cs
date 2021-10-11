using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : LoadingScreen
{
    [SerializeField]
    GameObject ButtonNext;
    [SerializeField]
    GameObject ButtonMenu;
    [SerializeField]
    GameObject ButtonSkip;


    string text1 = "the crimson moon , a magical gem that's said to glow in the light of a full moon.\nAnd beneath the moon and a certain comet, will shed a tear granting immortality to whomever drinks it.";
    string text2 = "Many people have been looking for it for years..\nMaybe even decades.\nBut all of them shared the same fate..";
    string text3 = "Death.";


    protected override void Start()
    {
        base.textString = text1;
        base.Start();
        StartCoroutine(WaitForText(11f));
    }
        

    public override void ChangeText()
    {
        if (base.textString.Equals(text1))
        {
            StartCoroutine(WaitForText(6));
            base.textObject.text = "";
            base.textString = text2;
            base.Start();
        }
        else
        if (base.textString.Equals(text2))
        {
            StartCoroutine(WaitForText(1));
            base.textObject.text = "";
            base.textString = text3;
            base.Start();
            ButtonNext.SetActive(false);
            ButtonMenu.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    protected  IEnumerator WaitForText(float sec)
    {
            ButtonNext.SetActive(false);
            yield return new WaitForSeconds(sec);
             ButtonNext.SetActive(true);
    }

    }














