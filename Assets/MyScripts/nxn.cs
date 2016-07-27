using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class nxn : MonoBehaviour {
    GameObject[] g = new GameObject[3];
    public static bool n = false;
   
    // Use this for initialization
    void Start () {
        g = GameObject.FindGameObjectsWithTag("containertextbox");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Click()
    {


        if (g[g.Length - 1].active)
        {
            for (int i = g.Length - 1; i > 0; i--)
                g[i].SetActive(false);
           n= true;
           
        }
        else {
            for (int i = g.Length - 1; i > 0; i--)
                g[i].SetActive(true);
            n = false;
        }
    }
}
