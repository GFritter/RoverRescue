using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cell : MonoBehaviour
{

    public int x, y;
    public bool alive;

    public bool futureAlive;
    public bool onHighlight = false;

    public GameObject[] neighbours =new GameObject[8];
   
    public Cell()
    {

    }

   public Cell(int _x,int _y, bool alive)
    {
        x = _x;
        y = _y;
        this.alive = alive;
       
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
        controlColor();
        
    }

    private void OnMouseDown()
    {
        alive =! alive;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onHighlight)
            controlColor();
       
     }

    public void checkState()
    {

        if(alive)
        {
            if(countAliveNeigbours()<2 || countAliveNeigbours()>3)
            {
              futureAlive = false;
               
            }
            else
            futureAlive = true;
        }

        else
        {
            if(countAliveNeigbours() == 3)
            {
               futureAlive = true;
                return;
            }
            else
            futureAlive = false;
        }

    }

    public void checkState(Condition life,Condition death)
    {

        if (alive)
        {
            if(death.useEqual)
            {
                if (countAliveNeigbours() == death.Equal)
                {
                    futureAlive = false;
                }

                else
                    futureAlive = true;

            }

            else
            {
                if (countAliveNeigbours() < death.LessThan || countAliveNeigbours() > death.MoreThan)
                {
                    futureAlive = false;

                }
                else
                    futureAlive = true;
            }
          
        }

        else
        {
            if(life.useEqual)
            {
                if (countAliveNeigbours() == life.Equal)
                {
                    futureAlive = true;
                    return;
                }
                else
                    futureAlive = false;
            }

            else
            {

                if (countAliveNeigbours() < life.LessThan || countAliveNeigbours() > life.MoreThan)
                {
                    futureAlive = true;

                }
                else
                    futureAlive = false;

            }
        }

    }

    public void controlColor()
    {
        if (alive)
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;


        else
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;

    }

    int countAliveNeigbours()
    {
        int count = 0;

        for(int i=0;i<neighbours.Length;i++)
        {
            if (neighbours[i].GetComponent<Cell>().alive)
                count++;
        }

        Debug.Log(count);
        return count;
    }

    public void setCell(Cell c)
    {
        x = c.x;
        y = c.y;

        alive = c.alive;

        neighbours = c.neighbours;
      
    }

    public void setNeighbour(GameObject[] n)
    {
        neighbours = n;
    }

    public virtual void updt()
    {
        controlColor();
        alive = futureAlive;
    }

    private void OnMouseOver()
    {
        colorNeighbours();
        countAliveNeigbours();
        
    }

    private void OnMouseExit()
    {
        reColorNeighbours();
    }

    public virtual void colorNeighbours()
    {
        for(int i = 0; i < neighbours.Length; i++)
        {
            neighbours[i].GetComponent<Cell>().onHighlight = true;
            neighbours[i].GetComponent<SpriteRenderer>().color = Color.green;
               
        }
    }


   public virtual void reColorNeighbours()
    {
        for (int i = 0; i < neighbours.Length; i++)
        {
            neighbours[i].GetComponent<Cell>().onHighlight = false;
            neighbours[i].GetComponent<SpriteRenderer>().color = Color.white;

        }
    }



}
