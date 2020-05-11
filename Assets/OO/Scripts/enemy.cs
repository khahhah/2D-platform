using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject stonepref;

    int s_left = -1;

    float bossSpeed = 15f;
    float stoptime = 4f;
    public float hp = 100f;
    public float b_attack = 10;

    GameObject B_hpbar; //보스 체력
    // Start is called before the first frame update
    void Start()
    {
        B_hpbar = GameObject.Find("B_hp");
    }

    // Update is called once per frame
    void Update()
    {
        stoptime += Time.deltaTime;
        if (stoptime > 3f)
        {
            transform.Translate(Time.deltaTime * bossSpeed * s_left, 0, 0);
        }
        transform.localScale = new Vector3(-1 * s_left, 1, 1);

        bosshp();
    }

    void bosshp()       //보스 체력표시
    {
        B_hpbar.GetComponent<Image>().fillAmount = hp / 100f;
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
        if (hp < 50)
        {
            GameObject stone = Instantiate(stonepref) as GameObject;
            float xpos = GameObject.FindWithTag("Player").GetComponent<Transform>().position.x;
            stone.transform.position = new Vector2(xpos, 5.5f);
            bossSpeed = 20f;
        }
    }
}
