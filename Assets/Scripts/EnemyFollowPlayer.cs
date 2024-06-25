using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float fireRate = 1f;
    private float nextFireTime;
    private Transform player;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Destroy(bullet, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time && (player.position.y <= (this.transform.position.y + 2) && player.position.y >= (this.transform.position.y - 2) && player.position.x < this.transform.position.x - 1)) {
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
        }
    }



}



/*float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)//remove when crash mechanics are applied
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position , speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange &&nextFireTime < Time.time && ((player.position.y <= (this.transform.position.y + 2) && player.position.y >= (this.transform.position.y - 2))) && player.position.x < this.transform.position.x) {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
        }*/