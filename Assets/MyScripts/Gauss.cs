using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;

public class Gauss : MonoBehaviour {
    public InputField inp1;
    public InputField inp2;
    public InputField inp3;
    public InputField inp4;
    public InputField inp5;
    public InputField inp6;
    Button b;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public GameObject g6;
    // Use this for initialization
    void Start () {
        b = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        b.onClick.AddListener(() => { Click(); });
    }
  public  void Click()
    {
        int size = 6;
        if (inp6.text == "" && g6.active)
        {
            g6.SetActive(false);
            size--;
        }
        else
            g6.SetActive(true);
        if (inp5.text == "" && g5.active)
        {
            g5.SetActive(false);
            size--;
        }
        else
            g5.SetActive(true);
        if (inp4.text == "" && g4.active)
        {
            size--;
            g4.SetActive(false);
        }
        else
            g4.SetActive(true);
        if (inp3.text == "" && g3.active)
        {
            g3.SetActive(false);
            size--;
        }
        else
            g3.SetActive(true);
        if (inp2.text == "" && g2.active)
        {
            size--;
            g2.SetActive(false);
        }
        else
            g2.SetActive(true);
        if (inp1.text == "" && g1.active)
        {
            size--;
            g1.SetActive(false);
        }
        else
            g1.SetActive(true);

        ///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////////
        ///
        int sirows = 0;
        string []srows=new string[size];
        srows[0] = inp1.text;
        srows[1] = inp2.text;
        srows[2] = inp3.text;
        //srows[3] = inp4.text;
        // srows[4] = inp5.text;
        // srows[5] = inp6.text;

       
            string[] ss = srows[0].Split(',');
        for (int i = 0; i < ss.Length; i++)
            sirows++;
        
        int[,] irows = new int[size,sirows];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < sirows; j++)
            {
                string[] s = new string[sirows];
                s = srows[i].Split(',');
                irows[i, j] = Convert.ToInt32(s[j]);
            }
        Debug.Log(irows.Length+" "+irows[0,0]);
        ///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////////
        ///
        int pivot = 0;
        for (int i = 0; i < srows.Length; i++)
        {
            if (irows[0, 0] == 1)
                break;
            if (irows[i, 0] == 1 && i != 0) {
                for (int j = 0; j < sirows; j++)
                {
                    int[] temp = new int[sirows];
                    temp[j] = irows[0, j];
                    irows[0, j] = irows[i, j];
                    irows[i, j] = temp[j];
                }
            }
        }

        pivot = irows[0, 0];
        bool flag = false;
        int o = 0;
        int current = 0,ii=0,counter=0;
        int k = 0;
        for (; k < srows.Length; k++)
        {
           
            counter++;
            ii = counter;
            for (; ii < srows.Length; ii++)
            {
                for (int j = 0; j < sirows; j++)
                {
                    if (flag == false)
                    {
                        flag = true;
                        pivot = irows[k, o];
                        current = irows[ii, k] / pivot ;
                       
                    }
                  
                    
                    irows[ii, j] -= current* irows[k, j];
                   
                }
                flag = false;
            }
            o++;
            
        }
        ///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////////
        ///
    
        int[] tt = new int[sirows];
        int gccd = 0;
        bool[] bb = new bool[sirows];
        for (int i = 0; i < bb.Length; i++)
            bb[i] = false;
        bool check = false;
        
        for (int i = 0; i < srows.Length; i++)
        {
            for (int j = 0; j < sirows; j++)
                if (irows[i, j] % 2 == 0&&irows[i,j]!=0)
                    bb[j] = true;
            //for (int b = 0; b < sirows; b++)
            //    if (irows[i, b] == 0)
            //        count++;
            //if (count != bb.Length)
            //    continue;
            for (int l = 0; l < bb.Length; l++)
            {
                if (bb[l])
                    check = true;
                else {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                for (int t = 0; t < sirows; t++)
                {
                    tt[t] = irows[i, t];
                }
                gccd = GreatestCommonDivisor(tt);
                for (int e = 0; e < sirows; e++)
                    irows[i, e] /= gccd;
            }
            for (int uii = 0; uii < bb.Length; uii++)
                bb[uii] = false;
        }

       
        bool flag1 = true;
        int piv = 0;
        int now = 0;
        int[] rowwithpiv=new int[sirows];
        int ee = srows.Length-1;
        for (int i = srows.Length-2; i >0 ; i--)
        {
          
            for (int j = sirows-1; j > 0; j--)
            {
                if (flag1 == true)
                {
                    piv = irows[srows.Length - 1, sirows - 2];
                    flag1 = false;
                    now = piv / irows[i, j];
                    
                        for (int u = 0; u < sirows - 1; u++)
                            rowwithpiv[u] = irows[ee, u];
                }
                
                irows[i, j] -= now*rowwithpiv[j];
            }
        }

         
        
        Debug.Log(pivot);
    }
    static int GreatestCommonDivisor(int[] numbers)
    {
        return numbers.Aggregate(GreatestCommonDivisor);
    }

    static int GreatestCommonDivisor(int x, int y)
    {
        return y == 0 ? x : GreatestCommonDivisor(y, x % y);
    }
}
