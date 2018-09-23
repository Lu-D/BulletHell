using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public Transform BossFront;
    public Transform target;
    public Health health;
    public int startHealth;
    public float coolDown;
    public float rotationSpeed;
    public GameObject gun;
    public GameObject bullet;
    //public float projSpeed;
    //public float spawnDistance;

    private AttackPatterns attackPatterns;
    private IEnumerator attackCoroutine;
    private int randomState;


    //Initialize fields
    void Start()
    {
        attackPatterns = new AttackPatterns();
        health = new Health(startHealth);

        gun = this.transform.Find("Gun").transform.gameObject;
        bullet = GameObject.FindGameObjectWithTag("Load").GetComponent<LoadList>().projectiles[0];

        randomState = 0;
    }

    // Execute every frame
    void Update()
    {

        //Set to look at player
        Vector3 relative = target.position;
        relative.x -= transform.position.x;
        relative.y -= transform.position.y;

        Quaternion lookDirection = Quaternion.LookRotation(-relative, Vector3.back);
        lookDirection.x = 0;
        lookDirection.y = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotationSpeed);

        //Ensures only one instance of coroutine is running and attack states are switched
        if (!attackPatterns.getIsAttacking())
        {
            attackStates();
            StartCoroutine(attackCoroutine);
        }
    }

    //attackStates()
    //Loops attack states and switches out attackCoroutine
    void attackStates()
    {
        if (randomState == 0)
        {
            attackCoroutine = attackPatterns.shootgun(gun, bullet, 5, 2);
        }
        else if (randomState == 1)
        {
            attackCoroutine = attackPatterns.shootStraight(gun, bullet, 5, 2);
        }
        else if (randomState == 2)
        {
            attackCoroutine = attackPatterns.shootWave(gun, bullet, 1, 2);
        }

        randomState++;
        if(randomState > 2)
        {
            randomState = 0;
        }
    }

    //collision method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Lose health when colliding with player projectile
        if(collision.gameObject.tag == "Player Projectile")
        {
            health.subtractHealth(collision.gameObject.GetComponent<BProjectile>().damage);
            Debug.Log(health.getHealth());
        }
    }
}