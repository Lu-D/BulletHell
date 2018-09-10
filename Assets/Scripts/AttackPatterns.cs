using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatterns 
{
    private bool isAttacking;

    public AttackPatterns()
    {
        isAttacking = false;
    }

    //public IEnumerator shootStraight(GameObject gun, GameObject bullet)
    //{
    //    yield return attackPieces.shootLine(gun, bullet, 10, 0);
    //    yield return attackPieces.shootLine(gun, bullet, 10, 60);
    //    yield return attackPieces.shootLine(gun, bullet, 10, -60);
    //}

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


    public bool getIsAttacking()
    {
        return isAttacking;
    }
}
