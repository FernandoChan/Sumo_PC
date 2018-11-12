using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    //    //这里演示下如何让Main Camera跟随在角色身后，随着角色旋转而保持在角色身后，类似生化危机这样第三人称的效果，工程前置为新建一个Cube命名为Player作为角色。代码如下：
    //    public class CameraFollow : MonoBehaviour
    //    {
    private GameObject m_Player; //角色
    public Vector3 offset; //角色与摄像机位置偏差值
    private float _pointX; //玩家X走旋转角度
    private float _pointY; //玩家Y轴旋转角度
    private float _pointZ; //玩家Z轴旋转角度
    public float damping = 1; //摄像机旋转阻尼
    private Vector3 camera_StartPos;



    void Start()
    {
        camera_StartPos = this.transform.position;
        m_Player = GameObject.FindGameObjectWithTag("Player");

        //摄像机与玩家之间的位置偏差值
        //玩家position-摄像机position也可，后面根据公式对应改为m_Player.transform.position-(rotatiom * offset)即可
        offset = camera_StartPos - m_Player.transform.position; //角色与摄像机位置偏差值

    }

    //        //在Update()中编写摄像机跟随代码，如果仅根据上面获得的二者位置偏差值，像下面这样写则只会实现摄像机保持固定距离跟随注视角色，但不会随着角色的旋转而旋转，这样有些类似于从空中完全俯视的上帝视角，不是我们想要的第三人称跟随。

    //        //void Update()
    //        //{
    //        //    //仅保持在后方注视，不跟随旋转
    //        //    transform.position = Vector3.Lerp(transform.position, m_Player.transform.position - offset, Time.deltaTime);
    //        //    transform.LookAt(m_Player.transform.position);
    //        //}

    //        //下面的写法通过获取角色Y轴欧拉角，并将其转换为四元数（四元数代表一个旋转）后，使用四元数*
    //        //    偏差值向量 = 得到一个在偏差值向量基础上被改变了四元数指代的那么多的旋转的一个新向量，并将新的偏差值+角色的position赋值给Main Camera的position。—
    //        //—到此步已经完成了摄像机跟随角色的旋转，但还没添加摄像机注视LookAt角色，这个很简单只需增加一句transform.LookAt(m_Player.transform.position);
    //        //即可，代码如下：

    //        void Update()
    //        {
    //            //第三人称跟随，随时保持角色后方跟随
    //            _pointY = m_Player.transform.eulerAngles.y; //实时获取玩家的Y轴旋转

                  //Debug.Log(_pointY);//0~360
    //            Quaternion rotation = Quaternion.Euler(0, _pointY, 0); //将玩家Y轴旋转转换为四元数（代表一个三维旋转）
    //            //rotatiom * offset：四元数*一个向量代表=将该向量转四元数代表的角度，即将该旋转应用到该向量，得到一个新的向量。体现为摄像机随着角色的旋转而左右旋转（但还没以角色为中心注视）
    //            this.transform.position = Vector3.Lerp(m_Player.transform.position + transform.position, m_Player.transform.position + (rotation * offset),
    //                Time.deltaTime * damping);

    //            //transform.position = Vector3.SmoothDamp(transform.position, character.position + new Vector3(0, 0, -5), ref cameraVelocity, smoothTime);


    //            //让摄像机从自身位置注视玩家位置，功能实现完成。
    //            //transform.LookAt(m_Player.transform.position);
    //            //LookAt();//LookAt手动实现,相机注视角色
    //        }

    //        //这里再补充一个LookAt手动实现的代码，方便在一些特殊的模型LookAt时候使用（如模型一开始带了迷之旋转之类）



    //        void LookAt()
    //        {
    //            var dir = (m_Player.transform.position - this.transform.position).normalized;
    //            var quat = Quaternion.LookRotation(dir);
    //            transform.rotation = quat;
    //        }



    //    }
    //}



    public GameObject objectToFollow;

    public float speed = 2.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y+0.3f, interpolation) ;
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x+0.5f, interpolation) ;
        position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z, interpolation) ;

        this.transform.position = position ;
    }
}
