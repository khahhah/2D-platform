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
}
