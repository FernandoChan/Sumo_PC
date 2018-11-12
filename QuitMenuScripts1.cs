using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScripts : MonoBehaviour {
    public Canvas quitCanvas;
    public bool isStartingGame;
    public Canvas MenuCanvas;
    public GameObject MenuUI;
    public GameObject IndoorScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isStartingGame)
        {
            MenuUI.SetActive(false);
            Time.timeScale = 0f;

            
        }
    }
}
