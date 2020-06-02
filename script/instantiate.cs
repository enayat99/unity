using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{

    public GameObject [] street;
    private List<GameObject> activeStreet;
    private int safoZone = -100;
    Transform playerTransform;
    float spawnZ = 0.0f;
    float streetLenght = 30.0f;
    int spawnAmongOnScreen = 30;
    int lastStreet = 0;
    // Start is called before the first frame update
    void Start()
    {
        activeStreet = new List<GameObject>();
         playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < spawnAmongOnScreen; i++)
        {
            SpawnStreet();
           
        }
    }
    private void Update()
    {
        if (playerTransform.position.z - safoZone > spawnZ - spawnAmongOnScreen + streetLenght)
        {
            SpawnStreet();
            DeleteStreet();
        }
    }

    private void SpawnStreet(int prefabeIndex = -1) {
        GameObject go;
        go = Instantiate(street[RandomIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += streetLenght;
        activeStreet.Add(go);
    }
    private int RandomIndex()
    {
        if (street.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastStreet;
        while (randomIndex == lastStreet)
        {
            randomIndex = Random.Range(0, street.Length);
        }
        lastStreet = randomIndex;
        return randomIndex;
    }

    private void DeleteStreet()
    {
        Destroy(activeStreet[0]);
        activeStreet.RemoveAt(0);
    }
}
