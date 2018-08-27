using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjList : MonoBehaviour {

    public GameObject[] projectiles;

    // Use this for initialization
    void Start () {
        projectiles = Resources.LoadAll("Projectile") as GameObject[];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
