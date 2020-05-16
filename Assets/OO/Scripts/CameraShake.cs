using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float count;
    bool crush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void CameraShaker()
    {
        StartCoroutine("Shaking");
    }
    IEnumerator Shaking()
    {
        int count = 0;
        while (count<6)
        {
            if (count%2==0)
                transform.position = new Vector3(0.3f, 0, -10f);
            else transform.position = new Vector3(-0.3f, 0, -10f);
            yield return new WaitForSeconds(0.05f);
            count++;
        }
        transform.position = new Vector3(0, 0, -10f);
        yield return null;
    }
}
