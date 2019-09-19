using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PetriNet/Transition")]
public class Scr_Transition : ScriptableObject
{
    public int id;
    public bool ready;
    public List<Scr_Connection> connInList;
    public List<Scr_Connection> connOutList;
   

   

    public bool isReady()
    {
        return ready;
    }

    public void insertConnection(Scr_Connection conn)
    {

        if (conn.isEntry())
            connInList.Add(conn);

        else
            connOutList.Add(conn);



    }

    public int getId()
    {
        return id;
    }


    public void fire()
    {
        for (int i = 0; i < connInList.Count; i++)
        {
            Scr_Connection c = connInList[i];

            if(!c.isReset())
            {
                for (int j = 0; j < c.getWeight(); j++)
                {
                    Debug.Log("acessando pela conexao o place com id:" + c.getPlace().getId());
                    c.getPlace().RemoveToken();
                }
            }

            else
            {
                c.getPlace().Clear();
            }

         

        }


        for (int i = 0; i < connOutList.Count; i++)
        {
            Scr_Connection c = connOutList[i];


            for (int j = 0; j < c.getWeight(); j++)
            {
                Token t = new Token();
                c.getPlace().addToken(t);
            }
        }

        ready = false;
    }

    public void checkReady()
    {

        ready = false;
        int count = 0;

        for (int i = 0; i < connInList.Count; i++)
        {
            Scr_Connection c = connInList[i];

            if (!c.isInhibitor())
            {
                if (c.getReady())
                {
                    count++;
                }
            }

            else
            {
                if (c.getReady())
                    count--;
            }



        }

        if (count == connInList.Count)
            ready = true;

    }
}
