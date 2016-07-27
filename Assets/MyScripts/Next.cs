using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Next : MonoBehaviour {
    public TextField t1;
    public TextField t2;
    public TextField t3;
    int size = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Click()
    {
        string text = "";
        text += t1.GetComponent<Text>().text;
        text += '\n';
        size++;
        text += t2.GetComponent<Text>().text;
        text += '\n';
        size++;
        text += t3.GetComponent<Text>().text;
        text += '\n';
        size++;
    }
}
