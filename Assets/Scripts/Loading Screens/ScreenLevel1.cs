using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLevel1 : LoadingScreen
{
        [SerializeField]
        GameObject ButtonNext;
        [SerializeField]
        GameObject ButtonPlay;


        string text1 = "The crimson cult , an organization full of thieves,mercenary,and necromancers from all over the world are hunting for the crimson moon.";
        string text2 = "They won't let anyone stands in their way, as they reign chaos all over the world in the hope to find the gem and achieve immortality.";
        string text3 = "Recent reports claim that the cult has taken control over the town of aven using an army of undead.";
        string text4 = "What could they be plotting for?";


    protected override void Start()
        {
            base.textString = text1;
            base.Start();
            StartCoroutine(WaitForText(8f));
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
            }
            else
        if (base.textString.Equals(text3))
        {
            base.textObject.text = "";
            base.textString = text4;
            base.Start();
            ButtonNext.SetActive(false);
            ButtonPlay.SetActive(true);
        }
    }

    public override void LoadLevel(int lv)
    {
        base.LoadLevel(lv);
    }

    protected IEnumerator WaitForText(float sec)
        {
            ButtonNext.SetActive(false);
            yield return new WaitForSeconds(sec);
            ButtonNext.SetActive(true);
        }

    }
















