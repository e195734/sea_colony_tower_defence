using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    private HP hp;
    private GameObject HPBar;

    // Start is called before the first frame update
    void Start()
    {
        this.hp = new HP(20);
        this.HPBar = Instantiate((GameObject)Resources.Load("HPBar"),
                                 transform.position,
                                 Quaternion.identity);
    }
    public void Init()
    {
    }
    private bool isDeath()
    {
        return this.hp.isZero();
    }

    void FixedUpdate(){}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int atk = collision.gameObject.GetComponent<Enemy>().getAttack();
            this.hp.damage(atk);
            this.HPBar.gameObject.GetComponent<HPBar>().updateHP(this.hp.getHPRatio());
        }
        if (isDeath())
        {
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroy(this.HPBar.gameObject);
    }
}
