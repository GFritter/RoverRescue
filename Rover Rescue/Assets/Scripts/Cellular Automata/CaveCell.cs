using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCell : Cell
{
    public Sprite floor, wall;
    public bool flooded;

    public CaveCell()
    {

    }

    public CaveCell(int _x, int _y, bool alive)
    {
        this.x = _x;
        this.y = _y;
        this.alive = alive;
    }

    // Start is called before the first frame update
    void Start()
    {
        controlColor();
    }

    // Update is called once per frame
    void Update()
    {


    }


    private void OnMouseOver()
    {
        //colorNeighbours();

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            flood();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            alive = !alive;
            controlColor();

        }


    }

    private void OnMouseExit()
    {
        reColorNeighbours();
    }

    new public void controlColor()
    {
        if (alive)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = wall;

        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = floor;

        if (flooded)
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        else
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

    override public void updt()
    {
     
        alive = futureAlive;
        controlColor();

    }

    public void flood()
    {
        if (alive || flooded)
            return;

        else
        {
            flooded = true;
            controlColor();


            neighbours[1].GetComponent<CaveCell>().flood();
            neighbours[3].GetComponent<CaveCell>().flood();
            neighbours[4].GetComponent<CaveCell>().flood();
            neighbours[6].GetComponent<CaveCell>().flood();




        }

    }

    public override void colorNeighbours()
    {

        neighbours[1].GetComponent<SpriteRenderer>().color = Color.green;
        neighbours[3].GetComponent<SpriteRenderer>().color = Color.green;
        neighbours[4].GetComponent<SpriteRenderer>().color = Color.green;
        neighbours[6].GetComponent<SpriteRenderer>().color = Color.green;

    }

    public override void reColorNeighbours()
    {

        for (int i = 0; i < neighbours.Length; i++)
        {
            neighbours[i].GetComponent<CaveCell>().controlColor();

        }
    }

}
