using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProj : BProjectile {

    private new void Start()
    {
        
    }

    private new void Update()
    {
        
    }

    private new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
