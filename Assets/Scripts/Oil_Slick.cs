using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Oil_Slick : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
   void Update()
    {
        if (transform.position.y < -screenBounds.y * 2) {
            Destroy(this.gameObject);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            print("WE HAVE COLLid");
            // StartCoroutine(player.OilReaction());
            StartCoroutine(player.OilReaction());

        }
        //Destroy(this.gameObject, 3f);// DETECTING COLLISION WHEN THERE IS NONE

    }



}
