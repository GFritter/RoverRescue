using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection 
{
    private bool inhibitorArc;
    private bool entryArc;
    private bool resetArc;
    private Place place;
    private Transition transition;

    private bool ready;

    private int weight;

    public Connection()
    {

    }

    public Connection(Place place, bool entryArc, bool inhibitorArc, bool resetArc,int weight)
    {
        this.inhibitorArc = inhibitorArc;
        this.entryArc = entryArc;
        this.resetArc = resetArc;

        this.place = place;
        this.weight = weight;

       
    }

    public bool isInhibitor()
    {
        return inhibitorArc;
    }

    public bool isEntry()
    {
        return entryArc;
    }
    
    public Place getPlace()
    {
        return place;
    }

    public int getWeight()
    {
        return weight;
    }

    public void setTransition(Transition t)
    {
        transition = t;
    }

    public Transition getTransition()
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
