using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PetriNet/Connection")]
public class Scr_Connection : ScriptableObject
{
    //change to scriptable object version of other objects

   public bool inhibitorArc;
    public bool entryArc;
    public bool resetArc;
    public Scr_Place place;
    public Scr_Transition transition;

    public bool ready;

    public int weight;

    public bool isInhibitor()
    {
        return inhibitorArc;
    }

    public bool isEntry()
    {
        return entryArc;
    }

    public bool isReset()
    {
        return resetArc;

    }

    public Scr_Place getPlace()
    {
        return place;
    }

    public int getWeight()
    {
        return weight;
    }

    public void setTransition(Scr_Transition t)
    {
        transition = t;
    }

    public Scr_Transition getTransition()
    {
        return transition;
    }

    public void setReady(bool r)
    {
        ready = r;
    }

    public bool getReady()
    {
        return ready;
    }

}
