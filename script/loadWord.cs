using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class loadWord : MonoBehaviour
{
     TextMeshProUGUI textMesh;
    TextAsset txtasset;
    public string myfile = "Words";
    string[] Allwords;
    int waitTime = 3;
    bool randomtime = true;
    int nextIndex = 30;
    private void Start()
    {
        StartCoroutine(randomInterval());
        textMesh = GetComponent<TextMeshProUGUI>();
        txtasset = (TextAsset)Resources.Load(myfile);
        //wordNum = accessCounter.colliodedCounter;
    }
    private void Update()
    {
        Allwords = txtasset.text.Split('\n');
        if (randomtime)
        {
            StartCoroutine(randomInterval());
            textMesh.text = Allwords[nextIndex].ToString();
        }
        
        //ReadString();
    }
    IEnumerator randomInterval()
    {
        randomtime = false;
        yield return new WaitForSeconds(waitTime);
        nextIndex++;
        randomtime = true;
    }
}
