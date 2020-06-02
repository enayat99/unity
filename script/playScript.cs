using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Button exitb;
    private void Start()
    {
        exitb = GetComponent<Button>();
        exitb.onClick.AddListener(exit);
    }
    public void PLay()
    {
        SceneManager.LoadScene("main");
    }
    public void exit()
    {
        Application.Quit();
        Debug.Log("game closed");
    }
   
}
