using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Wolf : MonoBehaviour
{

    private Animator animator;

    public int attack = 10; 
    public int speed = 1; 
    public int defence = 5;
    public int hp = 100;
    public Slider hpSlider;
    [Range(0,100)]
    public int hpmax=100;


    public const int AI_ATTACT_DISTANCE = 4;
    private float time;
    private float battletime;
    private float timeincrease;
    private bool isturn;
    public float turnSpeed;//转向速度


    private GameObject player;
    public Vector3 initialPosition;

    public float wanderRadius;//巡逻半径
    public float alertRadius;//警戒半径
    public float defendRadius;//攻击半径
    private float distanceToPlayer;//距离玩家距离
    private float distanceToInitial;//距离初始位置距离
    private Quaternion targetRotation;//目标朝向

    // Use this for initialization
    void Start()
    {
        hp = hpmax;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = this.transform.position;
        time = 0; battletime = 0;
        timeincrease = 0.02f;
        animator.SetBool("isseat", true);
        hpSlider.value = hpSlider.maxValue = hp;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = hp;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Weapon")
        {
            Destroy(this.gameObject);
            Global.isBattle = false;                                                    
        }
            
    }

    private void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        distanceToInitial = Vector3.Distance(transform.position, initialPosition);
        //自由巡逻
        if (Global.isBattle == false && distanceToPlayer > alertRadius)
        {
            if (distanceToInitial > wanderRadius)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                time = 6;
            }
            time = time + timeincrease;

            if (time < 3 && time > 0)
            {
                animator.SetBool("isidle", false);
                animator.SetBool("isseat", true);
            }
            else if (time < 6)
            {
                animator.SetBool("isseat", false);
                animator.SetBool("isidle", true);
            }
            else if (time < 12)
            {
                animator.SetBool("isidle", false);
                animator.SetBool("iswalk", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (time < 20)
            {
                animator.SetBool("iswalk", false);
                animator.SetBool("iscreep", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime * 0.3f);
            }
            else
            {
                animator.SetBool("iscreep", false);
                animator.SetBool("isseat", true);
                time = 0;
                isturn = false;
            }
            if (time < 10 && time > 9 && !isturn)
            {
                float rotation = Random.value * 360;
                transform.Rotate(new Vector3(0, rotation, 0));
                isturn = true;
            }
        }
        //触发警戒
        else if (Global.isBattle == false && distanceToPlayer > defendRadius)
        {
            targetRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
            animator.SetTrigger("Creep");
        }
        //触发战斗
        else if (Global.isBattle == false && distanceToPlayer <= defendRadius)
        {
            Global.isBattle = true;//进入攻击半径，开始站东
        }
        //战斗
        else if (Global.isBattle == true)
        {
            targetRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
            battletime = battletime + timeincrease;//7秒攻击一次（变量可以修改）
            if (battletime < 2)
            {
                animator.SetTrigger("Creep");//准备攻击向后退一点
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Global.enemyattack = false;
            }
            else if (battletime < 6)
            {
                animator.SetTrigger("Run");//攻击动作
                if (distanceToPlayer > 0.5)
                {
                    transform.Translate(-Vector3.forward * speed * Time.deltaTime*0.5f);
                    Global.enemyattack = true;
                }
            }
            else battletime = 0;

            if (hp<= 0)
            {
                Destroy(this.gameObject);
                Global.isBattle = false;
            }

        }
    }
}
