using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shoot) 
        {
            StartCoroutine(fire());
        }
    }
    
    IEnumerator fire()
    {
        shoot = false;
        yield return new WaitForSeconds(3);
        Instantiate(bullet,gameObject.transform.position, Quaternion.identity);
        shoot = true;
    }
}
