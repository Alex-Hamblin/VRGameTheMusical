using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Vector3 newpos = player.position - gameObject.transform.position;
       
        newpos.Normalize();
        rb.AddForce(newpos *300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
