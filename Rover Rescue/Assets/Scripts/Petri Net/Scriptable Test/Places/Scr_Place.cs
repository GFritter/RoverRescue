using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PetriNet/Place")]
public class Scr_Place : ScriptableObject
{

    public int id;
    public bool empty;
    public ArrayList tokensList = new ArrayList();
    public List<Scr_Connection> connList;
    public List<Function> funcList;

    public int tempCountList = 0;

    public bool ready = false;





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
        tokensList.RemoveAt(tokensList.Count - 1);
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

    public void addConn(Scr_Connection c)
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


       tempCountList = tokensList.Count;
        List<Scr_Connection> t_conns = new List<Scr_Connection>();

        if (connList.Count > 1)
        {
            Solver s = new Solver();
            t_conns = s.solveConflict(connList);
        }

        else
            t_conns = connList;

        for (int i = 0; i < t_conns.Count; i++)
        {
            Scr_Connection c = t_conns[i];

            if (c.isInhibitor())
            {
                if (tokensList.Count > 0)
                {
                    c.setReady(true);
                }
            }

            else
            {
                if (tempCountList >= c.getWeight())
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
        }

        if (ready)
        {
            Debug.Log("Eu sou o place: " + id + " e eu estou pronto e vou chamar minha funcao");
            if (funcList.Count > 0)
            {
                for (int i = 0; i < funcList.Count; i++)
                {
                    funcList[i].Trigger();
                }
            }
        }

        return ready;

    }

}
