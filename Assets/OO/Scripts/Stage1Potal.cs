using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1Potal : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        text.text = "↑키를 누르면 이동합니다";
        if(collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("Stage 1");
        }
    }
}
