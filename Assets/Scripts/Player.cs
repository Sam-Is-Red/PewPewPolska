
using System.Collections;
using Unity.Profiling;
using Unity.Profiling.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Projectile bulletPrefab;
    
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    public Transform bulletPos;

    public float cooldown;
    float cooldownTimestamp;

    public float slowMovement;
    float slowTimestamp;
    public float SlowSubtrahend = 2f;

    public float health;

    public bool hitOil;



    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();


        if (hitOil == true)
        {
            rb2d.velocity = moveInput * (moveSpeed - SlowSubtrahend);
        }

        else { rb2d.velocity = moveInput * moveSpeed; }


        if (Input.GetKey(KeyCode.Space) && Time.time > cooldownTimestamp && hitOil == false)
        {
            cooldownTimestamp = Time.time + cooldown;
            SideShoot();
            print("Shooting!");
        }

        if (Input.GetKey(KeyCode.C) && hitOil == false) 
        {
            rb2d.velocity = moveInput * (moveSpeed + 10);
        }
        

    }

    public IEnumerator OilReaction()
    {
        hitOil = true;
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        yield return wait;
        hitOil = false;

    }


    private void SideShoot()
    {
        Projectile projectile = Instantiate(this.bulletPrefab, bulletPos.position, Quaternion.identity);
    }

    public void TakeDamage(float damage)
    {
        
        health -= damage;
        if (health <= 0f)
        {
            //Instantiate(this.laserPrefab, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name != "Invader_02")
        {
            Destroy(collision.gameObject);

        }
        
        Debug.Log("Collision detected with " + collision.gameObject.name);



    }*/


}
