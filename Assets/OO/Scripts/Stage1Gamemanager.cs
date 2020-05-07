using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Gamemanager : MonoBehaviour
{
    [SerializeField]
    GameObject B_hpbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bosshp();
    }
    void bosshp()
    {
        float hp = GameObject.FindWithTag("Enemy").GetComponent<enemy>().hp;
        B_hpbar.GetComponent<Image>().fillAmount = hp / 100f;
    }
}
