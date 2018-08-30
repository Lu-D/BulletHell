using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPieces
{

    //public IEnumerator shootLine(GameObject gun, GameObject bullet, int numOfBullets, float angle)
    //{
    //    for (int i = 1; i <= numOfBullets; ++i)
    //    {
    //        gun.GetComponent<GunControl>().Fire(bullet, angle);
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    public void shootLine(GameObject gun, GameObject bullet, int numOfBullets, float angle)
    {
        float timeStamp = 0;
        float CD = 0;
        int i = 1;

        while (i <= numOfBullets && Time.time > timeStamp + CD)
        {
            gun.GetComponent<GunControl>().Fire(bullet, angle);
            timeStamp = Time.time;
            ++i;
            //yield return new WaitForSeconds(0.2f);
        }
    }
}
