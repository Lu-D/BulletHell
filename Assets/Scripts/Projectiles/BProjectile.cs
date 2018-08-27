using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BProjectile : MonoBehaviour
{
    public virtual void Start()
    {

    }

    public void Update()
    {

    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}