using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb2d;
    public int bulletspeed;
    public GameObject playerbulletprefab;


    private GameObject bulletInstance;
  private Vector2 moveInput;
    private Vector3 shootDirection;

    private Camera cam;
    private Transform my;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb2d.velocity = moveInput * moveSpeed;
               
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;

        //SHOOT BUllet
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

    }
    private void FixedUpdate()
    {
        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = cam.transform.position.y - my.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        body.rotation = angle;
    }


        public void Fire()
    {
        
        bulletInstance = Instantiate(playerbulletprefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        bulletInstance.SetActive(true);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * bulletspeed, shootDirection.y * bulletspeed);
    }



}
