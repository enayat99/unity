using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showScore : MonoBehaviour
{
    public wordScript accessWordScript;
    // Start is called before the first frame update
    TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = accessWordScript.colliodedCounter.ToString();
        
    }
}
