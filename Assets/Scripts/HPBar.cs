using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHP(float ratio)
    {
        transform.GetChild(0).gameObject.GetComponent<Slider>().value = ratio;
    }

    public void updatePosition(Vector3 pos)
    {
        this.transform.position = pos;
    }
}
