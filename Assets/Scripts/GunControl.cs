using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//On actual gun gameObject to fire projectile
public class GunControl : MonoBehaviour
{
    private Transform gunBack;
    private Transform gunFront;
    private Transform boss;
    public float coolDown;
    private float maxCoolDown;
    public GameObject bullet;


    // Use this for initialization
    void Start()
    {
        gunBack = this.gameObject.transform.GetChild(0);
        gunFront = this.gameObject.transform.GetChild(1);
        boss = this.gameObject.transform.parent;
        maxCoolDown = coolDown;
    }

    //Fire()
    //fires projectile in the foward direction
    public void Fire(GameObject proj, float angle)
    {
        transform.Rotate(0, 0, angle, Space.Self);

        //fire Projectile
        GameObject projectile = (GameObject)Instantiate(bullet, gunFront.position, boss.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = (gunFront.position - gunBack.position) * projectile.GetComponent<BProjectile>().projSpeed;
        coolDown = maxCoolDown;
        transform.Rotate(0, 0, -angle, Space.Self);

    }
}
