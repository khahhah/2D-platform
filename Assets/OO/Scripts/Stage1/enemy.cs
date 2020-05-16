using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject stonepref;

    GameObject child;
    public Animator b_animator;

    int s_left = -1;

    float bossSpeed = 15f;
    public float stoptime = 0f;
    public float hp = 100f;
    public float b_attack = 10;
    public Text hp_text;

    public bool angry = false;
    public bool start = false;    //보스가 멈춰있을때


    GameObject b_hpbar; //보스 체력

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        b_hpbar = GameObject.Find("B_hp");
        b_animator = child.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationUpdate();
        stoptime += Time.deltaTime;
        if (hp > 0)
        {
            BossMove();
        }

        bosshp();
    }
    void AnimationUpdate()
    {
        if (start)
        {
            b_animator.SetBool("isStart", true);
        }
    }
    void BossMove() //보스의 이동패턴
    {
        if (stoptime > 3f && start)
        {
            GetComponent<Collider2D>().enabled = true;
            b_animator.Play("run");
            transform.Translate(Time.deltaTime * bossSpeed * s_left, 0, 0);
        }
        transform.localScale = new Vector3(-1 * s_left, 1, 1);
    }

    void bosshp()       //보스 체력표시
    {
        b_hpbar.GetComponent<Image>().fillAmount = hp / 100f;
        hp_text.text = hp + " / 100";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            stoptime = 0;
            s_left = -1 * s_left;
            Skill();
            Camera.main.GetComponent<CameraShake>().CameraShaker();
        }
    }

    void Skill()
    {
       
        if (hp <= 50 && !angry)
        {

            Debug.Log("발동");
            angry = true;
            child.GetComponent<SpriteRenderer>().color = new Color32(200, 30, 30, 255);
            b_animator.Play("idle");
            bossSpeed = 20f;
            if (stoptime < 3f)
            {
                GetComponent<Collider2D>().enabled = false;
            }

        }
        if(angry)
        {
            GameObject stone = Instantiate(stonepref) as GameObject;
            float xpos = GameObject.FindWithTag("Player").GetComponent<Transform>().position.x;
            stone.transform.position = new Vector2(xpos, 5.5f);
        }
    }
    
}
