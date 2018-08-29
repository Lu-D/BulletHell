using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
    private Transform gunBack;
    private Transform gunFront;
    private Transform boss;
    public float coolDown;
    private float maxCoolDown;
    public GameObject bullet;


    // Use this for initialization
    void Start () {
        gunBack = this.gameObject.transform.GetChild(0);
        gunFront = this.gameObject.transform.GetChild(1);
        boss = this.gameObject.transform.parent;
        maxCoolDown = coolDown;
    }
	
	// Update is called once per frame
	void Update () {
        //Fire(bullet, 90); //FOR TEST PURPOSES ONLY
        //Fire(bullet, -90);
        //Fire(bullet, 0);
	}

    public void Fire(GameObject proj, float angle)
    {
            transform.Rotate(0, 0, angle, Space.Self);
            //fire Projectile
            GameObject projectile = (GameObject)Instantiate(bullet, gunFront.position, boss.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = (gunFront.position - gunBack.position) * projectile.GetComponent<BProjectile>().projSpeed;
            coolDown = maxCoolDown;
            //Debug.Log(projectile.GetComponent<Rigidbody2D>().velocity);
            //Debug.Log(gunFront.position - gunBack.position);
            //Debug.Log(projectile.GetComponent<BProjectile>().projSpeed); 
            transform.Rotate(0, 0, -angle, Space.Self);
        
    }
}
