using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProj : MonoBehaviour {

    public GameObject[] projectiles;

    // Use this for initialization
    void Start () {
        projectiles = Resources.LoadAll("Projectiles") as GameObject[];
        Debug.Log(projectiles);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
