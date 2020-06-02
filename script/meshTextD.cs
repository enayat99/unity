using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class meshTextD : MonoBehaviour
{
    public wordScript accessWordscript;
    public TextMeshProUGUI textMesh;
    TextAsset txtasset;
    public  string myfile = "Words";
    string[] Allwords;
    public string temtextMesh ;
     int wordNum;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
         txtasset = (TextAsset)Resources.Load(myfile);
        //wordNum = accessCounter.colliodedCounter;
    }
    private void Update()
    {
        wordNum = accessWordscript.colliodedCounter;
        Allwords = txtasset.text.Split('\n');
        textMesh.text = Allwords[wordNum].ToString();
        //ReadString();
    }
}
