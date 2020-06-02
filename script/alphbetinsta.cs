using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphbetinsta : MonoBehaviour
{
    public GameObject[] letter;
    Transform playerTransform;
    float spawnZ;
    float spawnX;
    float spawnDestiancZ=5;
    int spawnAmongOnScreen = 200;
    int letterLenghnt = 10;
    int lastStreet = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("letters").transform;
        for (int i = 0; i < spawnAmongOnScreen; i++)
        {
            SpawnStreet();
        }
    }
    private void Update()
    {

    }

    private void SpawnStreet(int prefabeIndex = -1)
    {

        spawnX = Random.Range(-4, 3);
        spawnDestiancZ=Random.Range(20,40);
        float spawnDestiancX = Random.Range(-4, 0);

        GameObject go;
        go = Instantiate(letter[RandomIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        go.transform.position = new Vector3(spawnX,1, go.transform.position.z);
        spawnZ += spawnDestiancZ;
        spawnX += spawnDestiancX;
    }
    private int RandomIndex()
    {
        if (letter.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastStreet;
        while (randomIndex == lastStreet)
        {
            randomIndex = Random.Range(0, letter.Length);
        }
        lastStreet = randomIndex;
        return randomIndex;
    }
}
