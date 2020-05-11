using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Gamemanager : MonoBehaviour
{
    
    float bosshp;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        bosshp = GameObject.FindWithTag("Enemy").GetComponent<enemy>().hp;
        youwin();

    }
    void youwin()
    {
        if (bosshp <= 0)
        {
            Debug.Log("너 이겼어");
            //gameObject.GetComponent<LobbyGameManager>().stage1boss = true;
            SceneManager.LoadScene("Lobby");
        }
    }
    
}
