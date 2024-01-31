using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GAMESCRIPT : MonoBehaviour
{

    public int score;

    public int roundtimer = 10;
    public int spawnpoints= 3;

    public GameObject Enemy;
    public GameObject EnemyHeavy;
    
    public GameObject Item;
    public GameObject spwanWall; public int wallcounter=2;

    private GameObject spawnEnemy;



    public TextMeshProUGUI ScoreLive;

    private int heavyroundon = 5;
    private int roundcounter=0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreLive.text = "Score:" + score;
        StartCoroutine(waiter(roundtimer, spawnpoints));


    }

    void Awake()
    {
        spwanWall.SetActive(true);
        Enemy.SetActive(true);
        EnemyHeavy.SetActive(true);
        Item.SetActive(true);

        Instantiate(Enemy, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity); 
        Instantiate(Enemy, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity); 
        Instantiate(Enemy, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
        Instantiate(EnemyHeavy, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);

        Instantiate(Item, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);

        for (int i = 0; i < wallcounter; i++) { Instantiate(spwanWall, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity); }
    }


   IEnumerator waiter(int roundtimer,int spawnpoints)
    {


        yield return new WaitForSeconds(roundtimer);
        roundcounter++;

       // GameObject.FindWithTag("WALL").transform.position = new Vector3(1, 1, 1);

        Instantiate(Enemy, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);

        for(int i = 0; i < spawnpoints; i++) { Instantiate(Enemy, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity); }
       

            if (roundcounter== heavyroundon) { 
        EnemyHeavy.SetActive(true);
        Instantiate(EnemyHeavy, new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
            roundcounter = 0;

           
          

        }

        StartCoroutine(waiter(roundtimer, spawnpoints));
    }
      
    public void scorep(int value) { score += value; ScoreLive.text = ""+score; }

    // Update is called once per frame
    void Update()
    {
        
    }
}
