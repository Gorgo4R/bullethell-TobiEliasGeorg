using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthitem : MonoBehaviour
{

    PLAYERLIFE my_object;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
                Destroy(gameObject);
                my_object = GameObject.Find("Playeer Mesh").GetComponent<PLAYERLIFE>();
                my_object.getlife(5);
        }
           




        
    }
}



