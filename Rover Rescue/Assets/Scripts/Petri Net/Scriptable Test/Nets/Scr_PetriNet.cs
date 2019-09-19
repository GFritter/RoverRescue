using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PetriNet/Petri Net")]
public class Scr_PetriNet : ScriptableObject
{
    public List<Scr_Place> placeList;
    public List<Scr_Transition> transitionList;

   

    public void execCycle()
    {

        for (int i = 0; i < placeList.Count; i++)
        {
            Scr_Place p = placeList[i];
            p.checkReady();
        }

        for (int i = 0; i < transitionList.Count; i++)
        {
            Scr_Transition t = transitionList[i];
            t.checkReady();

        }

        for (int i = 0; i < transitionList.Count; i++)
        {
            Scr_Transition t = transitionList[i];
            if (t.isReady())
            {
                t.fire();
            }

        }
    }

    public void ClearAllPlaces()
    {
        for(int i=0;i<placeList.Count;i++)
        {
            placeList[i].Clear();
            placeList[i].checkReady();
        }

        for (int i = 0; i < transitionList.Count; i++)
        {
             transitionList[i].checkReady();
            

        }

    }

    //transition
    public bool insertTransition(Scr_Transition t)
    {
        transitionList.Add(t);

        return true;
    }

    public Scr_Transition getTransition(int pos)
    {
        return transitionList[pos];
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
    public bool removeTransition(Scr_Transition target)
    {
        if (transitionList.Contains(target))
        {
            transitionList.Remove(target);
            return true;
        }

        else
            return false;

    }
    public List<Scr_Connection> getConnectionsEntry(int id)
    {
        for (int i = 0; i < transitionList.Count; i++)
        {
            Scr_Transition t = transitionList[i];

            if (t.getId() == id)
            {
                return t.connInList;
            }
        }

        return null;
    }
    public List<Scr_Connection> getConnectionsOut(int id)
    {
        for (int i = 0; i < transitionList.Count; i++)
        {
            Scr_Transition t = transitionList[i];

            if (t.getId() == id)
            {
                return t.connOutList;
            }
        }

        return null;
    }

    //places
    public void insertPlace(Scr_Place p)
    {
        placeList.Add(p);
    }

    public Scr_Place getPlace(int pos)
    {
        return placeList[pos];
    }

    public Scr_Place getPlaceID(int id)
    {
        for (int i = 0; i < placeList.Count; i++)
        {
            if (placeList[i].id == id)
                return placeList[i];

        }


        return new Scr_Place();
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

    public bool removePlace(Scr_Place target)
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

    public bool createConnection(Place p, Transition t, int weight, bool isEntry, bool isInhibitor, bool isReset)
    {
        Connection c = new Connection(p, isEntry, isInhibitor, isReset, weight);
        t.insertConnection(c);

        return true;

    }
    public bool removeConnection(Place p, Transition t)
    {
        for (int i = 0; i < t.connInList.Count; i++)
        {
            Connection temp = (Connection)t.connInList[i];

            if (temp.getPlace() == p)
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
