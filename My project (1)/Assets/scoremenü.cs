using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class scoremenü : MonoBehaviour
{
    
    public TextMeshProUGUI ScoreLive;

    void Awake()
    {
        try
        {


            StreamReader sr = new StreamReader("Assets/HighestSCORE.txt");
            
            int linescore;
            int.TryParse(sr.ReadLine(), out linescore);

            ScoreLive.text = "" + linescore;

            sr.Close();



        }
        finally
        {
            Debug.Log("Executing Score");
        }
    }

   
}
