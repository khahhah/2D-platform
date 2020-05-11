using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{
    public Text Anykey;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PAK");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ChangeScene();
        }

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Lobby");
    }
    IEnumerator PAK()
    {
        while (true)
        {
            Anykey.GetComponent<Text>().text = " ";
            yield return new WaitForSeconds(0.5f);

            Anykey.GetComponent<Text>().text = "Press Any Key";
            yield return new WaitForSeconds(0.5f);

        }

    }
}
