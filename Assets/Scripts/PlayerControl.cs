using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public float dashDist;
    public float dashSpeed;
    public float rotateSpeed;
    public float dashCD;
    public bool invincible;

    private Rigidbody2D myRigidbody;
    private Renderer myRenderer;
    private bool dashing;
    private Health playerHP;
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

        /*
         * Input for dash move
         * 
         * 
         * */
        if (Input.GetKeyDown("space") && Time.time > timeStamp + dashCD)
        {
            timeStamp = Time.time;
            StartCoroutine(Dash(mousePos));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile" && !invincible)
        {
            Debug.Log("I got hit");
            StartCoroutine(collideFlash(1f));
            StartCoroutine(invinciblePhase(1f));
        }
    }

    IEnumerator Dash(Vector3 mousePos)
    {
        Vector3 target = transform.position + mousePos.normalized * dashDist;

        invincible = true;

        while (Vector3.Distance(transform.position, target) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePos, dashSpeed * Time.deltaTime);
            yield return null;
        }

        invincible = false;
    }

    //flash when damage taken
    IEnumerator collideFlash(float greyTimer)
    {
            Material m = this.myRenderer.material;
            Color32 c = this.myRenderer.material.color;
            this.myRenderer.material = null;
            this.myRenderer.material.color = Color.white;

            yield return new WaitForSeconds(greyTimer);

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
