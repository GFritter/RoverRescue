using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver 
{

    public List<Scr_Connection> solveConflict(List<Scr_Connection> original)
    {
        int r;

        List<Scr_Connection> temp = new List<Scr_Connection>();
        List<Scr_Connection> copy = original;

        for(int i=0;i<original.Count;i++)
        {
            r = Random.Range(0, original.Count - 1);

            temp.Add(copy[r]);
            copy.RemoveAt(r);
            

        }

        return temp;

    }
   
}
