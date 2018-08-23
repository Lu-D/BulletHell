using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public Transform target;
    public GameObject bullet;
    public float coolDown;
    public float projSpeed;
    public int spawnDistance;


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

        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        Vector3 direction = new Vector3(0, 0, angle + 90f);
        transform.rotation = Quaternion.Euler(direction);

        FireProjectiles(direction);
    }

    void FireProjectiles(Vector3 direction)
    {
        coolDown -= Time.deltaTime;
        if ( coolDown <= 0)
        {
            GameObject projectile = (GameObject)Instantiate(bullet, spawnDistance * direction, transform.rotation);
            Rigidbody2D proj = projectile.GetComponent<Rigidbody2D>();
            proj.AddForce(direction * projSpeed);
            coolDown = 5;
        }
    }
}