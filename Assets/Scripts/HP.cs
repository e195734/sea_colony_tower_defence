using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP
{
    private int initialHP;
    private int hp;

    public HP(int initialHP)
    {
        this.initialHP = initialHP;
        this.hp = initialHP;
    }

    public bool isZero()
    {
        return this.hp == 0; 
    }

    public void damage(int damage)
    {
        this.hp = Math.Max(this.hp - damage, 0);
    }

    public void heal(int amount)
    {
        this.hp = Math.Min(this.hp + amount, this.initialHP);
    }

    public float getHPRatio()
    {
        return (float)this.hp / (float)this.initialHP;
    }
}
