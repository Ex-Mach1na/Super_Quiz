using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject CategoryMenu;
    public GameObject MainMenu;
    public GameObject popup;
    public GameObject historymenu;
    public GameManager gameManager;
    private void Start()
    {
        
        Debug.Log(System.DateTime.Now.ToString());
    }

    public void loadScoreData()
    {
        ScoreManager.instance.loadData();
    }


    public void play()
    {
        MainMenu.gameObject.SetActive(false);
        CategoryMenu.gameObject.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }

    public void close()
    {
        popup.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);

    }
    public void yes()
    {
        popup.SetActive(false);
        gameManager.gameOver();
    }
    public void no()
    {
        popup.SetActive(false);
        
    }
    public void history()
    {
        MainMenu.gameObject.SetActive(false);
        historymenu.gameObject.SetActive(true);
    }
    public void historyClose()
    {
        MainMenu.gameObject.SetActive(true);
        historymenu.gameObject.SetActive(false);
    }

}
