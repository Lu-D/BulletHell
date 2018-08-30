using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatterns 
{
    private AttackPieces attackPieces;
    private bool isAttacking;

    public AttackPatterns()
    {
        attackPieces = new AttackPieces();
        isAttacking = false;
    }

    //public IEnumerator shootStraight(GameObject gun, GameObject bullet)
    //{
    //    yield return attackPieces.shootLine(gun, bullet, 10, 0);
    //    yield return attackPieces.shootLine(gun, bullet, 10, 60);
    //    yield return attackPieces.shootLine(gun, bullet, 10, -60);
    //}

    public IEnumerator shootThree(GameObject gun, GameObject bullet, int bulletNum, float CD)
    {
        isAttacking = true;
        for (int i = 1; i <= bulletNum; ++i)
        {
            gun.GetComponent<GunControl>().Fire(bullet, 0); 
            gun.GetComponent<GunControl>().Fire(bullet, 60);
            gun.GetComponent<GunControl>().Fire(bullet, -60);
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


    public bool getIsAttacking()
    {
        return isAttacking;
    }
}
