using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected HP hp;
    protected float moveSpeed;
    protected GameObject target;
    // Start is called before the first frame update
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Colony");
        moveSpeed = 1f;
        hp = new HP(10);
    }

    private void FixedUpdate()
    {
        if (target)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.FromToRotation(-Vector3.right, target.transform.position - this.transform.position);
        }
    }
    private bool isDeath()
    {
        return this.hp.isZero();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            int atk = collision.gameObject.GetComponent<Bullet>().getAttack();
            this.hp.damage(atk);
        }
        if (isDeath())
        {
            Destroy(this.gameObject);
        }
    }
}
