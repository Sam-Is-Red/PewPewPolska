using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Follow_Player : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float fireRate = 1f;
    private float nextFireTime;
    private Transform player;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public string tagName;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(tagName).transform;
        //Destroy(bullet, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //new
        player = GameObject.FindGameObjectWithTag(tagName).transform;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time && (player.position.x <= (this.transform.position.x + 2) && player.position.x >= (this.transform.position.x - 2) && player.position.y < this.transform.position.y))
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    

}
