using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovementShooter : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;

    public Rigidbody2D TargetObjTransform;
    public int SPEED;


    public int enemyLife = 5;


    public float changePosTimer=0;
    public float toX;
    public float toY;

    //public GameObject GAMESCRIPT;
    GAMESCRIPT my_object;
    public int getscore=10;

    private void FixedUpdate()
    {
        


        transform.position = Vector3.MoveTowards(transform.position, new Vector2(toX, toY), speed* Time.deltaTime);

        float angle = Mathf.Atan2(TargetObjTransform.position.y - transform.position.y, TargetObjTransform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, SPEED * Time.deltaTime);




    }

    void Awake()
    {
        toX = Random.Range(-8f, 8f);
        toY = Random.Range(-4.5f, 4.5f);
        StartCoroutine(waiter(changePosTimer));
    }

    IEnumerator waiter(float changePosTimer)
    {
        yield return new WaitForSeconds(changePosTimer);

         toX = Random.Range(-8f, 8f);
         toY = Random.Range(-4.5f, 4.5f);


        StartCoroutine(waiter(changePosTimer));
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PLayerBullet")
        {
            enemyLife--;
            if (enemyLife<0) { Destroy(gameObject); 
                my_object = GameObject.Find("GAMEMASTER").GetComponent<GAMESCRIPT>();
                my_object.scorep(getscore);
            }
            Destroy(collision.gameObject);


            

        }
    }



}