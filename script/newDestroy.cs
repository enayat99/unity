using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDestroy : MonoBehaviour
{
    public wordScript accessWordScript;
    public string PickedLetter;


    //destroying object
    private void Update()
    {
       
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "letters")
        {

           // PickedLetter = accessWordScript.textMeshPro.text.ToString();
           // Debug.Log("hi picked  " + PickedLetter);
            accessWordScript.checkCollide = true;

            Destroy(hit.gameObject);
        }
    }
}
