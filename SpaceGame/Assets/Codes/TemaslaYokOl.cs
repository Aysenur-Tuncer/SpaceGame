using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour
{
    public GameObject patlama;
    

    GameObject OyunKontrol;
    OyunKontrol kontrol;

    void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
          
        if(col.gameObject.tag=="lazer")
        {
            
            GameObject go=Instantiate(patlama, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
            Destroy(go, 1.5f);
            kontrol.ScoreArttir(10);
        }
         
       

      
    }

}
