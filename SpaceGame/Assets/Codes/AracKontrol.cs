using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AracKontrol : MonoBehaviour
{
    Rigidbody2D fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float karakterHiz;
    public float minX, maxX, minY, maxY;
    float atesZamani = 0;
    public float atesGecenSure;
    public GameObject Lazer;
    public Transform LazerNeredenCiksin;

    GameObject OyunKontrol;
    OyunKontrol kontrol;

    public GameObject playerPatlama;





    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();

        

        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();

    }

     void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > atesZamani)
        {
            atesZamani = Time.time + atesGecenSure;
            GameObject laserClone = Instantiate(Lazer, LazerNeredenCiksin.position, Quaternion.identity) as GameObject;
            Destroy(laserClone, 2.5f);
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, vertical,0);

        fizik.velocity = vec * karakterHiz;

        fizik.position = new Vector3
        (
            Mathf.Clamp(fizik.position.x, minX, maxX),
            Mathf.Clamp(fizik.position.y, minY, maxY),
            0.0f 
        ) ;
       

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "engel")
        {
            GameObject go= Instantiate(playerPatlama, col.transform.position, col.transform.rotation);
            Destroy(gameObject);
            Destroy(col.gameObject);
            Destroy(go, 1.0f);
            
            
            kontrol.GameOver();
        }
    }
    




}
