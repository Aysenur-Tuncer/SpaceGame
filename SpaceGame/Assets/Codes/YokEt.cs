using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokEt : MonoBehaviour
{
    GameObject OyunKontrol;
    OyunKontrol kontrol;
    void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
    }

    
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "engel")
        {
            kontrol.ScoreAzalt(10);
            Destroy(col.gameObject);
           
        }

            
    }
}
