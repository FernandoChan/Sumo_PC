using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    private Animator animator;

    public int attack = 10;
    public int speed = 1;
    public int defence = 5;
    public int life = 10;


    public const int AI_ATTACT_DISTANCE = 4;
    private float time;
    private float battletime;
    private float timeincrease;
    private bool isturn;
    public float turnSpeed;//转向速度


    private GameObject player;
    public Vector3 initialPosition;
    private bool isal;

    public float wanderRadius;//巡逻半径
    public float alertRadius;//警戒半径
    public float defendRadius;//攻击半径
    private float distanceToPlayer;//距离玩家距离
    private float distanceToInitial;//距离初始位置距离
    private Quaternion targetRotation;//目标朝向

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = this.transform.position;
        time = 0; battletime = 0;
        timeincrease = 0.02f;
        animator.SetBool("isidle", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        distanceToInitial = Vector3.Distance(transform.position, initialPosition);
        //自由巡逻
        if (Global.isBattle == false && distanceToPlayer > alertRadius)
        {
            if (isal == true)
            {
                isal = true;
                animator.SetBool("isfly", false);
            }
            if (distanceToInitial > wanderRadius)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                time = 18;
            }
            time = time + timeincrease;

            if (time < 8 && time >= 0)
            {
                animator.SetBool("isidle", true);
            }
            else if (time < 16)
            {
                animator.SetBool("isidle", false);
                animator.SetBool("isfly", true);
            }
            else if (time < 24)
            {
                animator.SetBool("isfly", false);
                animator.SetBool("iswalk", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (time < 32)
            {
                animator.SetBool("iswalk", false);
                animator.SetBool("isrun", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime * 2);
            }
            else
            {
                animator.SetBool("isrun", false);
                animator.SetBool("isidle", true);
                time = 0;
                isturn = false;
            }
            if (time < 23 && time > 22 && !isturn)
            {
                float rotation = Random.value * 360;
                transform.Rotate(new Vector3(0, rotation, 0));
                isturn = true;
            }
        }
        //触发警戒
        else if (Global.isBattle == false && distanceToPlayer < alertRadius && distanceToPlayer > defendRadius)
        {
            isal = true;
            targetRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
            animator.SetBool("isidle", false);
            animator.SetBool("isfly", true);
            animator.SetBool("isidle", false);
            animator.SetBool("isrun", false);
        }
        //触发战斗
        else if (Global.isBattle == false && distanceToPlayer <= defendRadius)
        {
            Global.isBattle = true;//进入攻击半径，开始站东
        }
        //战斗
        else if (Global.isBattle == true)
        {
            battletime = battletime + timeincrease;//7秒攻击一次（变量可以修改）
            if (battletime < 6)
            {
                animator.SetBool("isidle", false);
                animator.SetBool("isfly", true);
                animator.SetBool("isidle", false);
                animator.SetBool("isrun", false);
                transform.Translate(-Vector3.forward * speed * Time.deltaTime);
                Global.enemyattack = false;
            }
            else if (battletime < 9)
            {
                animator.SetBool("iswalk", false);
                animator.SetBool("isrun", true);
                animator.SetBool("isfly", false);
                animator.SetBool("isidle", false);
                if (distanceToPlayer > 1)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime * 2);
                    Global.enemyattack = true;
                }
            }
            else battletime = 0;


            if (life <= 0)
            {
                Destroy(this.gameObject);
                Global.isBattle = false;
            }

        }
    }
}
