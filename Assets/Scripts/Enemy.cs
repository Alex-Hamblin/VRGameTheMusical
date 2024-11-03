using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    bool shoot;
    [SerializeField]  bool istargeting;
    [SerializeField] Transform player;
    [SerializeField] Vector3 distance;
    bool cooldownl;
    // Start is called before the first frame update
    void Start()
    {
        shoot = true;
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //StartCoroutine(fire());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = transform.position - player.position;
        if (distance.x <2 && distance.z <10 && distance.z > -2 && distance.x > -10)

        {
             
           
            if (shoot)
            {
                StartCoroutine(fire());
            }
        

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
