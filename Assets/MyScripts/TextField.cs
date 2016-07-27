using UnityEngine;
using System.Collections;

public class TextField : MonoBehaviour
{
    GameObject f;
    // Use this for initialization
    void Start()
    {
        string quer = "pos";
         quer += gameObject.transform.name.Substring(gameObject.transform.name.Length-1);
        f = GameObject.Find(quer);
    }
    private TouchScreenKeyboard keyboard;
    // Update is called once per frame
    void Update()
    {

    }
    public string txt = "";

    void OnGUI()
    {
       

        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            print(nbTouches + " touch(es) detected");

            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (f.transform.position.x == touch.position.x && f.transform.position.y == touch.position.y)
                {
                    TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
                         TouchScreenKeyboard.hideInput = true;
                }
            }
            
            // if (touch.position==gameObject.transform.position)
            // {
            //      TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
            //      TouchScreenKeyboard.hideInput = true;
            //  }
          

            //txt= GUI.TextField(t, txt, 25);
        }
        Rect t = new Rect(transform.position.x, transform.position.y, gameObject.transform.localScale.x, gameObject.transform.localScale.y);

        txt = GUI.TextField(t, txt);
    }
}