using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    private HP hp = new HP(20);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private bool isDeath()
    {
        return this.hp.isZero();
    }

    // Update is called once per frame
    void FixedUpdate(){}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.hp.damage(5);
        }
        if (isDeath())
        {
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }
    }
}
