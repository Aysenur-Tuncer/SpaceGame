using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public GameObject Asteroid;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;
    public Text text;
    public Text oyunBittiText;
    public Text yenidenBaslaText;
    public Text BstScore;
    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;


    int score=0;
    int bestScore = 0;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("kayit");
        BstScore.text = "Best Score: " + bestScore;
        text.text = "Score: " + score;
        StartCoroutine(Olustur());

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("SpaceGame");
        }

    }
    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while (true)
        {
            for (int i = 0; i < 8; i++)
            {
                float Yekseni = Random.Range(-4.2f, 4.2f);
                Vector3 vec = new Vector3(10.85f, Yekseni);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }
            if (oyunBittiKontrol)
            {
                yenidenBaslaText.text = ("Press R to restart");
                yenidenBaslaKontrol = true;
                break;
            }

            yield return new WaitForSeconds(donguBekleme);  


        }

    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("kayit", bestScore);
        }
        text.text = "Score: " + score;
        //Debug.Log(score);
    }
    public void ScoreAzalt(int gelenScore2)
    {
        if(oyunBittiKontrol==false)
        {
         score -= gelenScore2;
            if (score <= 0)
            {
                score = 0;
            }
         text.text = "Score: " + score;
        }
       
    }
    public void GameOver()
    {
        oyunBittiText.text = "GAME OVER!";
        oyunBittiKontrol = true;
    }
}
