using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    private int id;
    private bool empty;
    [SerializeField] private ArrayList tokensList;
    private ArrayList connList;
    public List<Function> funcList;

    private bool ready = false;

    public Place(int id)
    {
        this.id = id;
        this.empty = true;
        tokensList = new ArrayList();
        connList = new ArrayList();
        funcList = new List<Function>();
    }

    public int getTokenAmout()
    {
        Debug.Log("eu sou o place:" + id + " e retornei " + tokensList.Count + " tokens");
        return tokensList.Count;
   
    }

    public void addToken(Token token)
    {
        Debug.Log("eu sou o place:" + id + " e adicionei um token ");

        tokensList.Add(token);
        empty = false;
    }

    public void RemoveToken()
    {
        tokensList.RemoveAt(tokensList.Count-1);
    }

    public void Clear()
    {
        tokensList.RemoveRange(0, tokensList.Count);

    }

    public bool isEmpty()
    {
        return empty;
    }

    public int getId()
    {
        return id;
    }

    public void addConn(Connection c)
    {
        connList.Add(c);
    }

    public void addFunction(Function f)
    {
        funcList.Add(f);
    }

    public bool checkReady()
    {
        ready = false;

        int tempCountList = tokensList.Count;
        for(int i= 0; i<connList.Count;i++)
        {
            Connection c = (Connection)connList[i];

            if(tempCountList>= c.getWeight())
            {   
                ready = true;
                tempCountList -= c.getWeight();
                c.setReady(true);
               
            }

            else
            {
                c.setReady(false);
            }
        }

        if(ready)
        {
            Debug.Log("Eu sou o place: " + id + " e eu estou pronto e vou chamar minha funcao");
            if(funcList.Count>0)
            {
                for(int i=0;i<funcList.Count;i++)
                {
                    funcList[i].Trigger();
                }
            }
        }

        return ready;

    }


}
