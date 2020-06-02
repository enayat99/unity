using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeInstantiat : MonoBehaviour
{

    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 20; i++)
        {
            Instantiate(cube, new Vector3(0, 1, i), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
