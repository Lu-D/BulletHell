using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public Transform target;
    public GameObject bullet;
    public float coolDown;
    public float rotationSpeed;
    public float projSpeed;
    public float spawnDistance;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 relative = target.position;
        relative.x -= transform.position.x;
        relative.y -= transform.position.y;

        //float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        //Vector3 direction = new Vector3(0, 0, angle + 90f);
        Quaternion lookDirection = Quaternion.LookRotation(-relative, Vector3.back);
        lookDirection.x = 0;
        lookDirection.y = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotationSpeed);
         
        FireProjectiles(relative);
    }

    void FireProjectiles(Vector3 direction)
    {
        coolDown -= Time.deltaTime;
        if ( coolDown <= 0)
        {
            Vector3 spawnPoint = Vector3.MoveTowards(transform.position, target.position, spawnDistance);
            GameObject projectile = (GameObject)Instantiate(bullet, spawnPoint, transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projSpeed;
            //Rigidbody2D instantiatedProj = projectile.GetComponent<Rigidbody2D>();
            //instantiatedProj.velocity.normalized *= projSpeed;
            coolDown = 5;
        }
    }
}