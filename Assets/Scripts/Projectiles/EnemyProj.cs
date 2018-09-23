using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from base projectile
public class EnemyProj : BProjectile
{
    private CircleCollider2D projCollider;

    //initialize fields
    private new void Start()
    {
        projCollider = GetComponent<CircleCollider2D>();
    }

    //executes every frame
    private new void Update()
    {
        //Deactivate collider when player is invincible
        if (GameObject.Find("Player").GetComponent<PlayerControl>().invincible)
        {
            projCollider.enabled = false;
        }
        else
        {
            projCollider.enabled = true;
        }
    }

    //collision method
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        //Destroy game object when in contact with player collider
        if (collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
