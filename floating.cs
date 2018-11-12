using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class floating : MonoBehaviour {

    float radian = 0; // 弧度
    public float perRadian = 0.01f; // 每次变化的弧度
    public float radius = 0.8f; // 半径

    float angle = 0; // 初始角度
    public float rotationAngle = 0.01f; // 左右旋转角

    Vector3 oldPos; // 开始时候的坐标
                    // Use this for buttons initialization
    Quaternion oldRot; // 开始时候的方向
                       // Use this for buttons initialization
    float dy;
    float ry;


    // Use this for initializat1ion
    void Start () {
        oldPos = transform.position; // 将最初的位置保存到oldPos
        oldRot = transform.rotation;

    }
	
	// Update is called once per frame
	void Update () {
        radian += perRadian; // 弧度每次加0.01
        dy = Mathf.Cos(radian) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以
        transform.position = oldPos + new Vector3(0, dy, 0);


        angle += rotationAngle;
        ry = Mathf.Sin(angle) * radius; // rotate by y axis

        Vector3 rotationVector3 = new Vector3(oldRot.x, oldRot.y, oldRot.z);
        rotationVector3 += new Vector3(0, ry, 0);
        Quaternion rotation = Quaternion.Euler(rotationVector3);
        transform.rotation = rotation;
        //transform.rotation = oldRot + new Quaternion(oldRot.w, 0, ry, 0);

    }
}
