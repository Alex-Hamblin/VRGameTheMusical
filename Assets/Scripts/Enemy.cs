using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator fire()
    {
        yield return new WaitForSeconds(3);
        Instantiate(bullet,gameObject.transform.position, Quaternion.identity);
    }
}
