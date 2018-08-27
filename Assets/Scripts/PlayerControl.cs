using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public float dashDist;
    public float dashSpeed;
    public float rotateSpeed;
    public float dashCD;
    public float projSpeed;
    public float attackCD;
    public GameObject front;
    public GameObject bullet;


    private Rigidbody2D myRigidbody;
    private Renderer myRenderer;
    private Health playerHP;
    private bool dashing;
    private bool invincible;
    private float timeStamp;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<Renderer>();
        playerHP = new Health(5);
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Basic movement, takes input axis to set constant velocity in 1 direction
         * 
         * 
         * */
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            myRigidbody.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, speed * Input.GetAxisRaw("Vertical"));
        }
        else
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
        }

        /*
         * Takes mouse location every frame
         * Has point of ship facing mouse at all times
         * */
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = mousePos - objectPos;

        Quaternion lookMouse = Quaternion.LookRotation(mousePos, Vector3.back);
        lookMouse.x = 0;
        lookMouse.y = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookMouse, rotateSpeed);

        //dash input
        if (Input.GetKeyDown("space") && Time.time > timeStamp + dashCD)
        {
            timeStamp = Time.time;
            StartCoroutine(Dash());
        }

        //fire projectile input
        if (Input.GetMouseButton(0) && Time.time > timeStamp + attackCD)
        {
            timeStamp = Time.time;
            fireProjectile();
        }
    }

    //collision method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //take damage if hit by projectile and is not invincible, flash for damage and initiate invincibility
        if(collision.gameObject.tag == "Projectile" && !invincible)
        {
            playerHP.subtractHealth(1);
            Debug.Log(playerHP.getHealth());
            StartCoroutine(collideFlash(1f));
            StartCoroutine(invinciblePhase(1f));
        }
    }
    
    //fires projectile
    void fireProjectile()
    {
        //instantiate bullet and add velocity toward front of player
        GameObject projectile = (GameObject)Instantiate(bullet, (front.transform.position - transform.position).normalized * 1.5f + transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = (front.transform.position - transform.position) * projSpeed;
    }

    //dash towards player front, invincible during dash
    IEnumerator Dash()
    {
        Vector3 target = (front.transform.position - transform.position).normalized * dashDist + transform.position;

        invincible = true;

        while (Vector3.Distance(transform.position, target) > .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, dashSpeed * Time.deltaTime);
            yield return null;
        }

        invincible = false;
    }

    //flash when damage taken
    IEnumerator collideFlash(float greyTimer)
    {
            //save initial material and color
            Material m = this.myRenderer.material;
            Color32 c = this.myRenderer.material.color;

            //switch color to grey
            this.myRenderer.material = null;
            this.myRenderer.material.color = Color.white;
            
            //wait set time
            yield return new WaitForSeconds(greyTimer);
            
            //return to initial material/color
            this.myRenderer.material = m;
            this.myRenderer.material.color = c;
    }

    //stay invincible for x seconds
    IEnumerator invinciblePhase(float invincibleTimer)
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTimer);
        invincible = false;
    }


}
