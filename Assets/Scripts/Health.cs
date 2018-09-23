using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Health class that keeps track of health
public class Health{
    private int health;
    private int healthMax;

    public Health(int hp)
    {
        health = hp;
        healthMax = hp;
    }

    public void setHealth(int hp)
    {
        health = hp;
    }

    public int getHealth()
    {
        if(health > healthMax)
        {
            health = healthMax;
        }
        else if(health < 0)
        {
            health = 0;
        }
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
