using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1Gamemanager : MonoBehaviour
{
    
    float bosshp;
    float playerhp;
    public GameObject pannel;
    public Text message;
    public Text p_anykey;
    string win, lose;
    float count;
    bool bstart;
    // Start is called before the first frame update
    void Start()
    {
        pannel.SetActive(false);
        win = "You Win!!!";
        lose = "You Lose..";

    }

    void Awake()
    {
        bstart = GameObject.FindWithTag("Enemy").GetComponent<enemy>().start;
    }
    // Update is called once per frame
    void Update()
    {
        bosshp = GameObject.FindWithTag("Enemy").GetComponent<enemy>().hp;
        playerhp = GameObject.Find("oo").GetComponent<playerMove>().p_hp;
        Youwin();
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"&& !bstart)
        {
            bstart = true;
            GameObject.FindWithTag("Enemy").GetComponent<enemy>().start = true;
            GameObject.FindWithTag("Enemy").GetComponent<enemy>().stoptime = -1f;
        }

    }
    void Youwin()
    {
        if (bosshp <= 0)
        {
            Debug.Log("너 이겼어");
            message.text = win;
            Result();
        }
        else if (playerhp <= 0)
        {
            Debug.Log("넌 졌어");
            message.text = lose;
            message.color = new Color32(200,50,50, 255);
            Result();
        }
    }
    void Result()
    {
        count += Time.deltaTime;
        if (count > 3.0f)
        {
            pannel.SetActive(true);
            Time.timeScale = 0;
            p_anykey.text = "Press any key to go Lobby";
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Lobby");
                Time.timeScale = 1;
            }
        }
    }
    
}
