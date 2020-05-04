using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int s_right = 1; //캐릭터가 오른쪽을 보고 있다.
    // Start is called before the first frame update
    void Start()
    {
        isground = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p_hp > 0)
        {
            m_control();
        transform.localScale = new Vector3(s_right, 1, 1);  //방향을 바꿔주기
        
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isground = true;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Vector2 damagedVelocity = Vector2.zero;
            if (s_right == 1) damagedVelocity = new Vector2(-2f, 3f);
            else damagedVelocity = new Vector2(2f, 3f);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(damagedVelocity, ForceMode2D.Impulse);

            p_hp -= GameObject.FindWithTag("Enemy").GetComponent<enemy>().b_attack;
        }
    }
    void die()
    {
        if (p_hp <= 0)
        {

            Debug.Log("게임오버 ㅠㅠ");
        }
    }
}
