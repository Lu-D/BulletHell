using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public Transform BossFront;
    public Transform target;
    //public GameObject bullet;
    public Health health;
    public int startHealth;
    //public float coolDown;
    public float rotationSpeed;
    //public float projSpeed;
    //public float spawnDistance;
    //private float maxCoolDown;


    // Use this for initialization
    void Start()
    {
        health = new Health(startHealth);
        //maxCoolDown = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relative = target.position;
        relative.x -= transform.position.x;
        relative.y -= transform.position.y;

        Quaternion lookDirection = Quaternion.LookRotation(-relative, Vector3.back);
        lookDirection.x = 0;
        lookDirection.y = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotationSpeed);
         
        //FireProjectiles();
    }

    //void FireProjectiles()
    //{
    //    coolDown -= Time.deltaTime;
    //    if ( coolDown <= 0)
    //    {
    //        Vector3 spawnPoint = Vector3.MoveTowards(transform.position, BossFront.position, spawnDistance);

    //        //fire Projectile
    //        GameObject projectile = (GameObject)Instantiate(bullet, spawnPoint, transform.rotation);
    //        projectile.GetComponent<Rigidbody2D>().velocity = (BossFront.position - transform.position) * projectile.GetComponent<BProjectile>().projSpeed;
    //        coolDown = maxCoolDown;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player Projectile")
        {
            health.subtractHealth(collision.gameObject.GetComponent<BProjectile>().damage);
            Debug.Log(health.getHealth());
        }
    }
}