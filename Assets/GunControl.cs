using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
    private Transform gunBack;
    private Transform gunFront;
    public float coolDown;
    private float projSpeed = 1;
    private float maxCoolDown;
    public GameObject bullet;


    // Use this for initialization
    void Start () {
        gunBack = this.gameObject.transform.GetChild(0);
        gunFront = this.gameObject.transform.GetChild(1);
        maxCoolDown = coolDown;
    }
	
	// Update is called once per frame
	void Update () {
        Fire(bullet, 0); //FOR TEST PURPOSES ONLY
	}

    void Fire(GameObject proj, float angle)
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            //fire Projectile
            GameObject projectile = (GameObject)Instantiate(bullet, gunFront.position, transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = (gunFront.position - gunBack.position) * projectile.GetComponent<BProjectile>().projSpeed;
            coolDown = maxCoolDown;
        }
    }
}
