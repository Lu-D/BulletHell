using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public Transform target;
    public float rotationSpeed;


    // Use this for initialization
    void Start () {
    }
	
    // Update is called once per frame
    void Update () {

        Vector3 relative = target.position;
        relative.x -= transform.position.x;
        relative.y -= transform.position.y;

        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90f));

    }
}
