using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
