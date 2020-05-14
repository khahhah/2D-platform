using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyGameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public Text question;

    bool ispause;

    string q1, q2;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        ispause = false;
        q1 = "겜끌꺼야?";
        q2 = "ㄹㅇ?";
        question.text = q1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        if (!ispause)
        {
            ispause = true;
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
        else if(ispause)
        {
            Cancle();
        }
    }
    
    public void ExitGame()
    {
        Debug.Log("버트니 눌린다");
        if(question.text == q1)
        {
            question.text = q2;
        }
        else if(question.text == q2)
        {
            Application.Quit();
        }
    }

    public void Cancle()
    {
        Debug.Log("버트니 눌린다");
        ispause = false;
        question.text = q1;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }
}
