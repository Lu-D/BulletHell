using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from base projectile class
public class PlayerProj : BProjectile {

    private new void Start()
    {
        
    }

    //collision method
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        //destroys projectiles when colliding with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
