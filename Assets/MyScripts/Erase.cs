using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Erase : MonoBehaviour {
    public GameObject gg;
 
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    public  void Click()
    {
        gg.GetComponent<Text>().text = "";
          GameObject[] g = new GameObject[3];
        g = GameObject.FindGameObjectsWithTag("textbox");
       
        for (int i = 0; i < g.Length; i++)
            g[i].GetComponent<InputField>().text = "";
       
    }
}
