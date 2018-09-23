using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attack Patterns class
//List of projectile attacks that gameobject can execute
public class AttackPatterns 
{
    //ensures only one instance of coroutine is running
    private bool isAttacking;

    //AttackPatterns Constructor
    //sets isAttacking = false
    public AttackPatterns()
    {
        isAttacking = false;
    }

    //shootgun()
    //Takes gun thats shooting, type of projectile being shot, number of bullets being shot, and cd for attack
    //Fire projectiles in wave starting -40 degrees from foward and ending 40 degrees from foward
    //returns IEnumerator for coroutines
    public IEnumerator shootgun(GameObject gun, GameObject bullet, int bulletNum, float CD)
    {
        isAttacking = true;
        for (int i = 1; i <= bulletNum; ++i)
        {
            for(int j = -40; j <= 40; j += 5)
            {
                gun.GetComponent<GunControl>().Fire(bullet, j);
            }
            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(CD);
        isAttacking = false;
    }

    //shootStraight()
    //Takes gun thats shooting, type of projectile being shot, number of bullets being shot, and cd for attack
    //Fires projectiles in a straight line
    //returns IEnumerator for coroutines
    public IEnumerator shootStraight(GameObject gun, GameObject bullet, int bulletNum, float CD)
    {
        isAttacking = true;
        for (int i = 1; i <= bulletNum; ++i)
        {
            gun.GetComponent<GunControl>().Fire(bullet, 0);
            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(CD);
        isAttacking = false;
    }

    //shootWave()
    //Takes gun thats shooting, type of projectile being shot, number of bullets being shot, and cd for attack
    //Shoots sinusoidal wave of projectiles
    //returns IEnumerator for coroutines
    public IEnumerator shootWave(GameObject gun, GameObject bullet, int bulletNum, float CD)
    {
        isAttacking = true;
        for (int i = 1; i <= bulletNum; ++i)
        {
            for (int j = -40; j <= 40; j += 5)
            {
                gun.GetComponent<GunControl>().Fire(bullet, j);
                yield return new WaitForSeconds(.03f);
            }

            gun.GetComponent<GunControl>().Fire(bullet, 45);
            yield return new WaitForSeconds(.1f);

            for (int j = 40; j >= -40; j -= 5)
            {
                gun.GetComponent<GunControl>().Fire(bullet, j);
                yield return new WaitForSeconds(.03f);
            }
            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(CD);
        isAttacking = false;
    }

    //getIsAttacking
    //return bool isAttacking
    public bool getIsAttacking()
    {
        return isAttacking;
    }
}
