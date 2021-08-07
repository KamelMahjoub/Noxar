using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    protected Text textObject;
    protected string textString;

    protected virtual void Start()
    {
        StartCoroutine(LoadText(textString, textObject));
    }


    protected virtual IEnumerator LoadText(string text,Text textObj)
    {
        foreach(char character in text.ToCharArray())
        {
            textObj.text += character;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public virtual void ChangeText() {}
    
    public virtual void LoadLevel(int lv)
    {
        UIManager.Instance.LoadNextLevel(lv);  
    }
   



}
