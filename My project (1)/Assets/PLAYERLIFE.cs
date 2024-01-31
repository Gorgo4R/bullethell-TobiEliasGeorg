using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class PLAYERLIFE : MonoBehaviour
{
    public TextMeshProUGUI textlc;
    public int life = 5;


    public TextMeshProUGUI ScoreLive;

    // Start is called before the first frame update
    void Start()
    {
        textlc.text = "LIFE:" + life;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getlife(int lifegain) { life += lifegain; textlc.text = "LIFE:" + life; }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            life--;

           if (life == 0) {

                try
                {


                    StreamReader sr = new StreamReader("Assets/HighestSCORE.txt");
                    // int linescore = sr.ReadLine();
                    int linescore;
                    int.TryParse(sr.ReadLine(), out linescore);

                    int currentscore;
                    int.TryParse(ScoreLive.text, out currentscore);



                    if (linescore < currentscore)
                    {
                        sr.Close();
                        StreamWriter sw = new StreamWriter("Assets/HighestSCORE.txt");
                        sw.WriteLine(currentscore);
                        sw.Close();
                    }
                    else { sr.Close(); }
                }
                finally
                {
                    Debug.Log("Executing Score"+ ScoreLive.text);
                }


                SceneManager.LoadScene(0); }

            textlc.text = "LIFE:" + life;
        }
    }
}
