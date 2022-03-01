using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerKontrol : MonoBehaviour
{
    Rigidbody2D fizik;
    public float hiz;

    


    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        
    }
     void Update()
    {
        
        
        transform.position += new Vector3(hiz * Time.deltaTime, 0, 0);
        
    }
   
}
    
    
