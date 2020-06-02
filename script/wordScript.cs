using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wordScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public newDestroy accessnewDestroy;
    public meshTextD accessmeshD;
    public int wordindex;
    private int waitTime = 3;
    private bool randomtime = true;
    public char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i','j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 'o', 'p', 'q', 'u', 'v', 'w', 'x', 'y', 'z' };
    string target;
    public int colliodedCounter=0;
    public bool checkCollide=false;
    void Start()
    {
        StartCoroutine(randomInterval());
        textMeshPro = GetComponent<TextMeshProUGUI>();


    }

    // Update is called once per frame
    void Update()
    {
        
        if (checkCollide == true)
        {
            string compareCh= textMeshPro.text.ToString();
            string target = accessmeshD.textMesh.text.ToString();
            if (compareCh == target)
            {
                Debug.Log("you got one ----");
                colliodedCounter++;
            }
            Debug.Log("i got---------" + compareCh);
            checkCollide = false;
        }
        wordChanging();
    }
    //changing word randomly 
    public void wordChanging()
    {
        float[] arr = { 0f, 1f, 2f, -2.7f, -1f, -2 };
        System.Random r = new System.Random();
        int ind = r.Next(0, arr.Length - 1);

        if (randomtime == true)
        {
            StartCoroutine(randomInterval());
            wordindex = r.Next(0, letters.Length - 1);
            textMeshPro.text = letters[wordindex].ToString();
        }
    }

    //waiting time to change the letters
    IEnumerator randomInterval()
    {
        randomtime = false;
        yield return new WaitForSeconds(waitTime);
        randomtime = true;
    }
    //destroying object
  

}
