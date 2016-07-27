



using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Linq;
using Mehroz;

public class Gauss2 : MonoBehaviour
{
    public InputField inp1;
    public InputField inp2;
    public InputField inp3;
  
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;

    
   public GameObject output;
    static bool swapp = false;
    public static string textt = "";
    static public bool n = false;
     string fromn = "";
    static string index = "";
    static bool kminus = false;
    static bool wasKzero = false;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Click()
    {
        output.GetComponent<Text>().text = "";
        GameObject t = GameObject.Find("Text");
        t.GetComponent<Text>().text = "";
        t = null;
        GC.Collect();
        int size = 3;
       





        ///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////////
       
        string[] srows = new string[size];
        int sirows = 0;
        double[,] irows=null;
        if (g1.active)
        {
            srows = new string[size];
            srows[0] = inp1.text;
            srows[1] = inp2.text;
            srows[2] = inp3.text;
            sirows = 0;



          


            string[] ss = new string[size];
            for (int i = 0; i < srows.Length; i++)
            {

                ss[i] += srows[i];

            }
            int tt = 0;
            for (int i = 0; i < size; i++)
                if (srows[i] == "")
                {
                    tt--;

                    srows[i] = null;
                }
            srows = new string[size - tt];
            for (int i = 0; i < srows.Length; i++)
                srows[i] = ss[i];
            string[] g = srows[0].Split(',');
            for (int i = 0; i < g.Length; i++)
                sirows++;
            irows = new double[size, sirows];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < sirows; j++)
                {
                    string[] s = new string[srows.Length];
                    s = srows[i].Split(',');
                    irows[i, j] = Convert.ToDouble(s[j]);
                }

        }
        else
        {
           
            fromn = inp3.text;
            string[] ss = fromn.Split('!');
           
            size = ss.Length;
            srows = new string[size];
            for (int i = 0; i < size; i++) 
                srows[i] = ss[i];
            string[] g = ss[0].Split(',');
            for (int i = 0; i < g.Length; i++)
                sirows++;
            irows = new double[size, sirows];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < sirows; j++)
                {
                    string[] s = new string[srows.Length];
                    s = srows[i].Split(',');
                    irows[i, j] = Convert.ToDouble(s[j]);
                }
        }
       
        int length = 0;
        int height = 0;
        bool issquare = false;
        if (sirows == srows.Length)
            issquare = true;

        double mnozz = 0;
        bool isdouble = false;
        double mnoz = 0;
        bool flag = false;
        int counterformnoz = 0;
        int fortarg = 0;
        int fork = 0;
        Fraction frac = new Fraction();
        issquare = false;
        irows = IszeroFirst(irows, sirows, srows.Length);
        for (int k = 0; k < srows.Length-1; k++)
        {
            double pivot = 0;
            irows = Divide(irows, sirows, srows.Length);
            irows = Dividethree(irows, sirows, srows.Length);
            if (!issquare)
            {
               
                pivot = FindPivotForBack(irows, sirows, srows.Length, k);
               
                if (pivot == 0)
                {
                    irows=Swap(irows, sirows, k);
                
                    pivot = FindPivotForBack(irows, sirows, srows.Length, k);
                    
                }
                height++;
                length++;
            }
            else
            {
                pivot = GetPivot(k, irows);
                if (pivot == 0)
                {
                   if (k == srows.Length - 1)
                        break;
                    irows = Swap(irows, sirows, k);
                    pivot = GetPivot(k, irows);
                    continue;
                }
            }
            double current = 0;
            fork = Convert.ToInt32(index);
            counterformnoz = k+1;
            fortarg = k + 1;
            double dcurrent = 0;
            for (int i = counterformnoz; i < srows.Length; i++)
            {
              
                for (int j = 0; j < sirows; j++)
                {
               
                    if (!flag)
                    {
                  
                        double temp = GetTarget(irows, counterformnoz, fork);
                    
                        mnoz = Moznik(pivot, GetTarget(irows, counterformnoz, fork));
                        frac.Numerator = Convert.ToInt64(temp);
                        frac.Denominator = Convert.ToInt64(pivot);
                        mnozz = temp;
                        mnozz /= pivot;
                        counterformnoz++;
                      

                        flag = true;
                    }

                    dcurrent = (GetCurrent(irows, k, j) / frac.Denominator) * frac.Numerator;
                    irows[i, j] -= dcurrent;
               


                }
                flag = false;
             
          


            }
          
        }
        ///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////////
        ///
        irows = Divide(irows, sirows, srows.Length);
        GC.Collect();

        ///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////////
        ///
        mnozz = 0;
         isdouble = false;
        irows = LastStep(irows, sirows, srows.Length);
        irows = CheckSwap(irows, sirows, srows.Length);
       
        double Backpivot = 0;
     
     
        
        for (int k = srows.Length-1; k >= 0; k--)
        {
            if (!issquare)
            {
                Backpivot = FindPivotForBack(irows, sirows, srows.Length, height);
               
                if (Backpivot == 0)
                {
                 
                    height--;
                    continue;
                }
               
                height--;

            }
            else
            {
                double pivot = GetPivot(k, irows);
                if (pivot == 0)
                {
                    continue;
                }

            }
       
          
                counterformnoz = k - 1;
          
            length = Convert.ToInt32(index);
            double dcurrent = 0;
            Fraction f = new Fraction();
            string numerator = "";
            string denominator = "";
            
            for (int i = counterformnoz; i >=0; i--)
            {
                for (int j = 0; j < sirows; j++)
                {
                    if (!flag)
                    {


                        if (issquare)
                        {
                            double temp = GetTarget(irows, counterformnoz, k);
                            mnoz = Moznik(Backpivot, GetTarget(irows, counterformnoz, k));
                            f.Numerator = Convert.ToInt64(temp);
                            f.Denominator = Convert.ToInt64(Backpivot);
                            mnozz = temp;
                            mnozz /= Backpivot;

                            counterformnoz--;

                            flag = true;
                        }
                        else
                        {
                            double temp = GetTarget(irows, counterformnoz, length);
                            mnoz = Moznik(Backpivot, GetTarget(irows, counterformnoz, length));
                            numerator = temp.ToString();
                            denominator =Backpivot.ToString();
                            mnozz = temp;
                            mnozz /= Backpivot;

                            counterformnoz--;

                            flag = true;
                        }


                    }
                   
                        dcurrent = (GetCurrent(irows, k, j)/Double.Parse(denominator)) * Double.Parse(numerator);
                        irows[i, j] -= dcurrent;
                 
                }
                flag = false;
                isdouble = false;


            }

            length--;
        }

        GC.Collect();

        irows = LastStep(irows, sirows, srows.Length);
        irows = CheckSwap(irows, sirows, srows.Length);
        
        string ass = new Fraction(5).ToString();
        
        
        for (int i = 0; i <srows.Length ; i++)
        {

            for (int j = 0; j < sirows ; j++)
            {
                if(irows[i,j].ToString().Length>8)
                output.GetComponent<Text>().text += new Fraction(irows[i, j].ToString().Substring(0,3)).ToString() + " ";
                else
                    output.GetComponent<Text>().text += new Fraction(irows[i, j].ToString()).ToString() + " ";
                if (j == sirows-2)
                    output.GetComponent<Text>().text += " |";
                ass += irows[i, j].ToString() + " ";
            }

            ass += '\n';
            output.GetComponent<Text>().text += '\n';

        }
        if(CheckForError(irows,sirows,srows.Length))
        Debug.Log("Congratulations! Succseed");
        else
            Debug.Log("Congratulations! Bad matrix! Cann't solve!");
        if (!CheckForError(irows, sirows, srows.Length))
            output.GetComponent<Text>().text = "This system has no solutions!";
    }
    
    double FindPivotForBack(double[,] arr, int sirows, int srows,int kk)
    {
        int res = 0;
        srows--;
        for (int k = srows; k >= 0; k--)
        {
            int counter = 0;
            double[] temp = new double[sirows];
            for (int j = 0; j < sirows; j++)
                temp[j] = arr[k, j];
            for (int j = 0; j < sirows; j++)
            {
                if (temp[j] != 0)
                    continue;
                else
                    counter++;
            }
            if (counter != sirows)
            {
                for (int j = 0; j < sirows; j++)
                    if (temp[j] != 0&&k== kk)
                    {
                        index = j.ToString();
                        Debug.Log(index+" "+temp[j].ToString());
                        kminus = true;
                        return Convert.ToDouble(temp[j]);

                    }
               
            }
        }
        return res;
    }
    double[,] IszeroFirst(double[,] arr, int sirows, int srows)
    {
        if (arr[0, 0] == 0)
            arr = Swap(arr, sirows, 0);
        return arr;
    }
    double[,] CheckSwap(double[,] arr, int sirows, int srows)
    {
        
        double[] s = new double[sirows];
        int counter = 0;
        bool f = true;
        double[] lasr = new double[sirows];
        for (int i = 0; i < sirows; i++)
            lasr[i] = arr[srows-1,i];
        for (int i = 0; i < srows; i++)
        {
            counter = 0;
            string a = "";
            string b = "";
            for (int j = 0; j < sirows; j++)
                s[j] = arr[i, j];
            for (int j = 0; j < sirows; j++)
            {
                if (s[j] != 0)
                    continue;
                else
                    counter++;
                
            }
            
            for (int j = 0; j < sirows; j++)
            {
                a+= s[j].ToString();
                b += lasr[j].ToString();
            }
            if (a == b)
            {
                f = false;
            }
            if(f)
            if (counter == sirows)
            {
                for (int j = 0; j < sirows; j++)
                {
                    arr[srows-1, j] = s[j];
                    arr[i, j] = lasr[j];

                }
                    break;
            }

        }
        return arr;
    }

    
  
    double[,] LastStep(double[,] arr, int sirows, int srows)
    {

       
        arr = Divide(arr, sirows, srows);
        arr = Dividethree(arr, sirows, srows);
        for (int k = srows - 1; k >= 0; k--)
        {

            double pivot = GetPivot(k, arr);
            if (pivot == 0)
                continue;
            if (pivot < 0)
                for (int j = 0; j < sirows; j++)
                    arr[k, j] *= -1;

        }
        return arr;
     }
    bool CheckForError(double[,] arr, int siros, int srows)
    {
        bool[] bb = new bool[siros];
        
        int counter=0;
        for (int i = 0; i < bb.Length; i++)
            bb[i] = false;
        counter = 0;
        for (int i = 0; i < srows; i++)
        {
            
            for (int j = 0; j < siros; j++)
            {
                if (arr[i, j] != 0)
                {
                
                    bb[j] = true;
                    counter++;
                }
                
            }
           
            for (int j = 0; j < siros; j++)
            {
                if (counter == 1)
                {
                    if (j == siros - 1)
                        if (arr[i, j] != 0)
                            return false;
                }
                  else {
                    counter = 0;
                    break;
                }
               
            }
           
        }

        return true;

    }
    double[,] Dividethree(double[,] arr, int sirows, int srows)
    {
        int countzero = 0;
        int[] tt = new int[sirows];
        int gccd = 0;
        bool[] bb = new bool[sirows];
        for (int i = 0; i < bb.Length; i++)
            bb[i] = false;
        bool check = false;

        for (int i = 0; i < srows; i++)
        {

            for (int j = 0; j < sirows; j++)
            {
                if (arr[i, j] % 3 == 0 || arr[i, j] == 0)
                    bb[j] = true;
                if (arr[i, j] == 0)
                    countzero++;
            }
            
            for (int l = 0; l < bb.Length; l++)
            {
                if (bb[l] && countzero < sirows - 1)
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
                    tt[t] = Convert.ToInt32(arr[i, t]);
                }
                gccd = GreatestCommonDivisor(tt);
                for (int e = 0; e < sirows; e++)
                    arr[i, e] /= gccd;
            }
            for (int uii = 0; uii < bb.Length; uii++)
            {
                bb[uii] = false;
                countzero = 0;
            }
        }
        return arr;

    }
    double[,] Divide(double[,] arr, int sirows,int srows)
    {
        int countzero = 0;
        int[] tt = new int[sirows];
        int gccd = 0;
        bool[] bb = new bool[sirows];
        for (int i = 0; i < bb.Length; i++)
            bb[i] = false;
        bool check = false;

        for (int i = 0; i < srows; i++)
        {
            
            for (int j = 0; j < sirows; j++)
            {
                if (arr[i, j] % 2 == 0 || arr[i, j] == 0)
                    bb[j] = true;
                if(arr[i,j]==0)
                    countzero++;
            }
          
            for (int l = 0; l < bb.Length; l++)
            {
                if (bb[l]&&countzero<sirows-1)
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
                    tt[t] =Convert.ToInt32(arr[i, t]);
                }
                gccd = GreatestCommonDivisor(tt);
                for (int e = 0; e < sirows; e++)
                    arr[i, e] /= gccd;
            }
            for (int uii = 0; uii < bb.Length; uii++)
            {
                bb[uii] = false;
                countzero = 0;
            }
        }
        return arr;

    }
    double[,] Swap(double[,] arr, int sirows, int i)
    {
        double[] temp = new double[sirows];
            for (int f = 0; f < sirows; f++)
                temp[f] = arr[i, f];
        
            for (int j = 0; j < sirows; j++)
            {
                arr[i, j] = arr[i + 1, j];
                arr[i + 1, j] = temp[j];
            }
        return arr;
     }
   
 
    double GetTarget(double[,]arr,int pivot, int WhicRow)
    {
        return arr[pivot, WhicRow];
    }
   
    double Moznik(double pivot, double target)
    {
        return target / pivot;
    }
    double GetCurrent(double[,]arr, int WhichRow, int WhichPos)
    {
        return arr[WhichRow,WhichPos];
    }
    double GetPivot(int WhichRow, double[,]arr)
    {
        double res =0;
        try
        {
            if (arr[WhichRow, WhichRow] != 0)
                return arr[WhichRow, WhichRow];
        }
        catch
        {
            if (arr[WhichRow-1, WhichRow-1] != 0)
                return arr[WhichRow-1, WhichRow-1];
        }
        int i = 0;
        while (res != 0)
        {
            res = arr[WhichRow, i];
            i++;
        }
        return res;
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
