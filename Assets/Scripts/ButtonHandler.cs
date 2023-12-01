using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject infosText;
    [SerializeField] private GameObject eventManager;
    [SerializeField] private GameObject button;
    
    public void UIElementDisplay(GameObject UI)
    {
        if(UI!=null)
        {
            UI.SetActive(!UI.activeSelf);
            this.SetText(UI.activeSelf ? "Hide" : "Show");
        }
    }

    public void SetText(string text)
    {
        transform.Find("Text").GetComponent<Text>().text = text;
    }

    public void StartButton(GameObject go)
    {
        eventManager.SetActive(true);
        go.SetActive(false);
        infosText.SetActive(false);
        button.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
