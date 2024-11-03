using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCube : MonoBehaviour
{

    [SerializeField] int cubesPerAxis;
    [SerializeField] float force;
    [SerializeField] float radius;
    [SerializeField] GameObject cubeDeathGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Explode(Vector3 explosionPos)
    {
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for(int z = 0; z < cubesPerAxis; z++)
                {
                    CreateCube(new Vector3(x, y, z), explosionPos);   
                }
            }
        }
        Destroy(gameObject);
    }

    void CreateCube(Vector3 coordinates, Vector3 explosionPos)
    {
        GameObject cube = Instantiate(cubeDeathGameObject);

        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = cube.GetComponent<Renderer>().material;

        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.GetComponent<Rigidbody>();
        rb.AddExplosionForce(force, explosionPos, radius);

        Destroy(cube, 2f);



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
