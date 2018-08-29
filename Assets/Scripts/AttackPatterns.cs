using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatterns{

    void Start()
    {
        
    }

    void Update()
    {

    }

    public IEnumerator WaveFire(GameObject gun, GameObject projectile)
    {

        for(int i = -30; i <= 30; i += 5)
        {
            gun.GetComponent<GunControl>().Fire(projectile, i);
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 30; i >= -30; i -= 5)
        {
            gun.GetComponent<GunControl>().Fire(projectile, i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
