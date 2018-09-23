using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base projectile class 
public class BProjectile : MonoBehaviour
{
    public float projSpeed;
    public int damage;

    //initialize fields
    public virtual void Start()
    {

    }

    //execute every frame
    public void Update()
    {

    }

    //collision methods
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy projectile when colliding with game border
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}