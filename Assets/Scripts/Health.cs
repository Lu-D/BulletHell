using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health{
    private int health;

    public Health(int hp)
    {
        health = hp;
    }

    public void setHealth(int hp)
    {
        health = hp;
    }

    public int getHealth()
    {
        Debug.Log("Current health = " + health);
        return health;
    }

    public void subtractHealth(int damage)
    {
        health -= damage;
    }

    public void addHealth(int plus)
    {
        health += plus;
    }
}
