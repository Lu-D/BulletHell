using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health{
    int health;

    Health(int hp)
    {
        health = hp;
    }

    void setHealth(int hp)
    {
        health = hp;
    }

    int getHealth()
    {
        Debug.Log("Current health = " + health);
        return health;
    }

    void subtractHealth(int damage)
    {
        health -= damage;
    }

    void addHealth(int plus)
    {
        health += plus;
    }
}
