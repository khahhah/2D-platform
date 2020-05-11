using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyGameManager : MonoBehaviour
{
    public bool stage1boss;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("게임 일시중지 만들예정");
    }
}
