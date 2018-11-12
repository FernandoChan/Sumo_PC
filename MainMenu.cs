using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public bool isStartingGame;
    //public Canvas MenuCanvas;

    public GameObject MenuUI;

    public Sprite btn_colorful; // colorful button sprite
    public Sprite btn_gray; // grayscale button sprite, indicating that this button is not interactable 

    [HideInInspector]
    public GameObject btn_start;
    public GameObject btn_continue;
    public GameObject btn_options;
    public GameObject btn_exit;
    
    

    public int progressType;// if there is any 进度? if no, type = 0 , otherwise, type =1 
    // Use this for initialization
    void Start () {
        //开始背景音乐
        
        MenuUI.SetActive(true);
       
        //menu judge:
        if (PlayerPrefs.HasKey("progressType") == false)
        {
            PlayerPrefs.SetInt("progressType", 0);
        }
        else
        {
            progressType = PlayerPrefs.GetInt("progressType", 0);
        }


        //开始变色
        if (progressType == 0) // no saved game 
        {
            //transform.Find("btn_GameStart").GetComponent<Image>().sprite = btn_colorful;
            //Debug.Log("The first button is refresh as colorful ");
            //btn_continue.SetActive(false);
            //btn_continue.GetComponent<Button>().interactable = false;
            //btn_continue.GetComponent<Image>().sprite = btn_gray;
            // text 变灰色
        }

        else
        {
            // 读取进度

           
        }
    }

    // Update is called once per frame
    void Update () {

        

        if (isStartingGame)
        {
            MenuUI.SetActive(false);
            Time.timeScale = 0f;
                }
    }

    public void btn_gameStart_event()
    {
        loadPlotScene();
        isStartingGame = true;
    }

    public void loadPlotScene()
    {
        //SceneManager.LoadScene("2Plot");
        //Scene nextScene = SceneManager.GetSceneByBuildIndex(2);
        SceneManager.LoadScene("Scene_outdoor and fighting", LoadSceneMode.Single);
        //SceneManager.LoadScene("terrain", LoadSceneMode.Single);

        Debug.Log("Button: gameStart is clicked");

    }



    public void btn_loadOptions()
    {
        MenuUI.SetActive(false);
        Debug.Log("Load Options Canvas. MenuUI close");
        //OptionUI.SetActive(true); 
        Debug.Log("Load Options Canvas. OptionUI activated");
    }

    public void btn_QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }

}
