using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition 
{
    private int id;
    private bool ready;
    public ArrayList connInList;
    public ArrayList connOutList;
    [SerializeField] private string _name { get; set; }

    public Transition(int id)
    {
        connInList = new ArrayList();
        connOutList = new ArrayList();
        this.ready = false;
        this.id = id;
    }

    public bool isReady()
    {
        return ready;
    }

    public void insertConnection(Connection conn)
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
        for(int i=0;i<connInList.Count;i++)
        {
            Connection c = connInList[i] as Connection;

            for(int j=0;j<c.getWeight();j++)
            {
                Debug.Log("acessando pela conexao o place com id:" + c.getPlace().getId());
                c.getPlace().RemoveToken();
            }

        }


        for(int i =0; i<connOutList.Count;i++)
        {
            Connection c = connOutList[i] as Connection;

            for(int j=0;j<c.getWeight();j++)
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

        for(int i=0;i<connInList.Count;i++)
        {
            Connection c = (Connection)connInList[i];
            
            if(!c.isInhibitor())
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
