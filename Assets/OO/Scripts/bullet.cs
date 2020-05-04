using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float bulletspeed = 20f;

    float shoottime = 0;
    float shooting = 1.0f;

    int front;

    public int attack = 1;
    // Start is called before the first frame update
    void Start()
    {
        front = GameObject.Find("Player").GetComponent<playerMove>().s_right;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();   
    }
    public void shoot()
    {
        transform.Translate(Time.deltaTime * bulletspeed * front, 0, 0);
        shoottime += Time.deltaTime;
        if (shoottime > shooting)
        {
            shoottime = 0;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("아파아이잉");
            collision.gameObject.GetComponent<enemy>().hp -= attack;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
