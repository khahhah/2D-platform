using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    float playerSpeed=3f;
    [SerializeField]
    float jumpPower = 100f;
    [SerializeField]
    private GameObject bullet;
    public int attack = 1;
    bool isground;
    public float p_hp = 100f;

    GameObject p_hpbar; //플레이어 체력바

    public int s_right = 1; //캐릭터가 오른쪽을 보고 있다.
    bool ishit; //플레이어가 피격을 당한 상태
    // Start is called before the first frame update
    void Start()
    {
        isground = true;
        ishit = false;
        p_hpbar = GameObject.Find("p_hp");
    }

    // Update is called once per frame
    void Update()
    {
        if (p_hp > 0)
        {
            m_control();
        transform.localScale = new Vector3(s_right, 1, 1);  //방향을 바꿔주기
        
        }
        Playerhp();
        die();
    }

    void m_control()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            s_right = 1;
            transform.Translate(Time.deltaTime * playerSpeed * s_right, 0,0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            s_right = -1;
            transform.Translate(Time.deltaTime * playerSpeed * s_right, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet1 = Instantiate(bullet) as GameObject;
            Vector2 pos = this.gameObject.transform.position;
            pos.y -= 0.2f;
            bullet1.transform.position = pos;
        }
        if (isground)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isground = false;
                GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower);
            }
        }
    }
    void die()          //듸짐
    {
        if (p_hp <= 0)
        {
            transform.Rotate(0, 0, 90);
        }
    }
    void Playerhp()
    {
        p_hpbar.GetComponent<Image>().fillAmount = p_hp / 100f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isground = true;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy"&& !ishit)
        {
            Vector2 damagedVelocity = Vector2.zero;
            if (s_right == 1) damagedVelocity = new Vector2(-2f, 3f);
            else damagedVelocity = new Vector2(2f, 3f);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(damagedVelocity, ForceMode2D.Impulse);

            p_hp -= GameObject.FindWithTag("Enemy").GetComponent<enemy>().b_attack;
            if (p_hp > 0)
            {
                ishit = true;
                StartCoroutine("Unhit");
            }
        }
    }
    IEnumerator Unhit()     //피격무적
    {
        int count = 0;
        while (count < 10)
        {
            if (count % 2 == 0)
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
            else
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
            yield return new WaitForSeconds(0.2f);


            count++;
        }
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

        ishit = false;
        yield return null;
    }

}
