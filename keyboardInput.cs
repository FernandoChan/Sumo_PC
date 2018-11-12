using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardInput : MonoBehaviour {
    int keyFrame = 0;
    // Use this for initialization
    void Start ()
	{
	   
	}
	
	// Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            //清空按下帧数
            keyFrame = 0;
            Debug.Log("任意键被按下");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("您按下了W键");
            keyFrame++;
            Debug.Log("A连按:" + keyFrame + "帧");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("您按下了S键");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("您按下了A键");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("您按下了D键");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("您按下了空格键");
        }

        //抬起按键
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("您抬起了W键");
            keyFrame = 0;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("您抬起了S键");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("您抬起了A键");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("您抬起了D键");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("您抬起了空格键");
        }
    }
}
