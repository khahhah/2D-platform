using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject stonepref;

    int s_left = -1;

    float bossSpeed = 10f;
    float stoptime = 4f;
    public float hp = 100f;
    public float b_attack = 10;
    // Start is called before the first frame update
    void Start()
    {
        
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
            bossSpeed = 15f;
        }
    }
}
