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

    private float maxCoolDown;
    private AttackPatterns attackPatterns;
    private IEnumerator attackCoroutine;


    // Use this for initialization
    void Start()
    {
        attackPatterns = new AttackPatterns();
        health = new Health(startHealth);
        maxCoolDown = coolDown;

        gun = this.transform.Find("Gun").transform.gameObject;
        bullet = GameObject.FindGameObjectWithTag("Load").GetComponent<LoadList>().projectiles[0];
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


        //if (!attackPatterns.getIsAttacking())
        //{
            attackStates();
            StartCoroutine(attackCoroutine);
        //}
    }

    //void FireProjectiles()
    //{
    //    coolDown -= Time.deltaTime;
    //    if (coolDown <= 0)
    //    {
            
    //        StartCoroutine(attackPatterns.shootStraight(gun, bullet, 5));
    //        //attackPatterns.shootStraight(gun, bullet);

    //        coolDown = maxCoolDown;
    //    }
    //}

    void attackStates()
    {
        int randomState = Random.Range(0, 2);
        if (randomState == 0)
        {
            attackCoroutine = attackPatterns.shootThree(gun, bullet, 5, 2);
        }
        else
        {
            attackCoroutine = attackPatterns.shootStraight(gun, bullet, 5, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player Projectile")
        {
            health.subtractHealth(collision.gameObject.GetComponent<BProjectile>().damage);
            Debug.Log(health.getHealth());
        }
    }
}