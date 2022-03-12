using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected int attack;
    protected float moveSpeed;
    protected float lifeTime = 0;
    protected float lifeTimeLimit;

    void Start()
    {
        this.attack = 5;
        this.moveSpeed = 3f;
        this.lifeTimeLimit = 5f;
    }

    void FixedUpdate()
    {
        this.transform.position -= this.transform.right * Time.deltaTime * moveSpeed;
        this.lifeTime += Time.deltaTime;
        if (lifeTime >= this.lifeTimeLimit)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    public int getAttack()
    {
        return this.attack;
    }
}