using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public float damage;

    private void Start()
    {
        Destroy(gameObject, 7f); 
    }
    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
    
  /*  private void OnTriggerEnter2D(Collider2D other)
    {
            Destroy(this.gameObject);
    }*/
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invader invader = collision.GetComponent<Invader>();
        Player player = collision.GetComponent<Player>();

        if (invader != null)
        {
            invader.TakeDamage(damage);

        }
        else if (player != null) 
        {
            player.TakeDamage(damage);
        }
        Destroy(this.gameObject);

    }
}
