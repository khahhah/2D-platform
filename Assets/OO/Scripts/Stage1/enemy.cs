using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject stonepref;

    GameObject child;
    Animator b_animator;

    int s_left = -1;

    float bossSpeed = 15f;
    float stoptime = -2f;
    public float hp = 100f;
    public float b_attack = 10;

    public bool angry = false;

    GameObject b_hpbar; //보스 체력
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        b_hpbar = GameObject.Find("B_hp");
        b_animator = child.GetComponent<Animator>();
        b_animator.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        stoptime += Time.deltaTime;
        if (hp > 0)
        {
            BossMove();
        }

        bosshp();
        //if (hp <= 50) angry = true;
    }
    void BossMove() //보스의 이동패턴
    {
        if (stoptime > 3f)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            stoptime = 0;
            s_left = -1 * s_left;
            Skill();
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
