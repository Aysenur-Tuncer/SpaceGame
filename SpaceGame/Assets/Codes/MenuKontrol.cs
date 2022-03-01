using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OyunaGit()
    {
        SceneManager.LoadScene("SpaceGame");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
}
