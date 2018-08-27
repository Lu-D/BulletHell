using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProj : BProjectile
{
    private CircleCollider2D projCollider;

    private new void Start()
    {
        projCollider = GetComponent<CircleCollider2D>();
    }

    private new void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerControl>().invincible)
        {
            projCollider.enabled = false;
        }
        else
        {
            projCollider.enabled = true;
        }
    }

    private new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
