using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetriNet 
{
   [SerializeField] private ArrayList placeList;
   [SerializeField] private ArrayList transitionList;

    public PetriNet()
    {
        placeList = new ArrayList();
        transitionList = new ArrayList();
    }

    public void execCycle()
    {

        for(int i=0;i<placeList.Count;i++)
        {
            Place p = (Place)placeList[i];
            p.checkReady();
        }

        for(int i=0;i<transitionList.Count;i++)
        {
            Transition t = (Transition)transitionList[i];
            t.checkReady();

        }

        for (int i = 0; i < transitionList.Count; i++)
        {
            Transition t = (Transition)transitionList[i];
           if(t.isReady())
            {
                t.fire();
            }

        }
    }

    //transition
    public bool insertTransition(Transition t)
    {
        transitionList.Add(t);

        return true;
    }

    public Transition getTransition(int pos)
    {
        return (Transition)transitionList[pos];
    }

    public bool removeTransition(int pos)
    {
        if (pos < transitionList.Count)
        {
            transitionList.RemoveAt(pos);
            return true;
        }

        else
            return false;
    }
    public bool removeTransition(Transition target)
    {
        if (transitionList.Contains(target))
        {
            transitionList.Remove(target);
            return true;
        }

        else
            return false;

    }
    public ArrayList getConnectionsEntry(int id)
    {
        for(int i=0;i<transitionList.Count;i++)
        {
            Transition t = (Transition)transitionList[i];

            if(t.getId()==id)
            {
                return t.connInList;
            }
        }

        return null;
    }
    public ArrayList getConnectionsOut(int id)
    {
         for (int i = 0; i < transitionList.Count; i++)
          {
              Transition t = (Transition)transitionList[i];

              if (t.getId() == id)
              {
                  return t.connOutList;
              }
          }

        return null;
    }

    //places
    public void insertPlace(Place p)
    {
        placeList.Add(p);
    }

    public Place getPlace(int pos)
    {
        return (Place)placeList[pos];
    }

    public bool removePlace(int pos)
    {
        if (pos < placeList.Count)
        {
            placeList.RemoveAt(pos);
            return true;
        }

        else
            return false;

    }

    public bool removePlace(Place target)
    {
        if (placeList.Contains(target))
        {
            placeList.Remove(target);
            return true;

        }

        else
            return false;
    }

    //connections

    public bool createConnection(Place p, Transition t, int weight, bool isEntry,bool isInhibitor,bool isReset)
    {
        Connection c = new Connection(p, isEntry, isInhibitor, isReset, weight);
        t.insertConnection(c);

        return true;

    }
    public bool removeConnection(Place p, Transition t)
    {
        for(int i=0;i<t.connInList.Count;i++)
        {
            Connection temp = (Connection)t.connInList[i];
            
            if(temp.getPlace() == p)
            {
                t.connInList.Remove(temp);
                return true;
            }
        }
        for (int i = 0; i < t.connOutList.Count; i++)
        {
            Connection temp = (Connection)t.connOutList[i];

            if (temp.getPlace() == p)
            {
                t.connOutList.Remove(temp);
                return true;
            }
        }

        return false;
    }
    public Place getPlaceFromConn(Connection conn)
    {
        return conn.getPlace();
    }
    public Transition getTransitionFromConn(Connection conn)
    {
        return conn.getTransition();
    }


}
