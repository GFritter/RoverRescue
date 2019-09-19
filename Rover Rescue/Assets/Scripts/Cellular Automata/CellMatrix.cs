using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMatrix : MonoBehaviour
{

   
   
    public int sizeX, sizeY;

    public Condition Life, Death;
    

    public GameObject cellPrefab;
    public GameObject[] matrixTotal = new GameObject[100];
    public GameObject[][] cellMatrix;

    public int LiveChance;
    public int numberOfCycles;


    // Start is called before the first frame update
    void Start()
    {
        
      
        cellMatrix = new GameObject[sizeY][];

        for(int i=0;i<sizeY;i++)
        {
           
           
            cellMatrix[i] = new GameObject[sizeX];
        }

        for(int y=0;y<sizeY;y++)
        {

            for(int x=0;x<sizeX;x++)
            {
                int i = Random.Range(0, 100);
                bool a = false;

                if (i <= LiveChance)
                    a = true;

               
              cellMatrix[y][x] = Instantiate(cellPrefab, new Vector3(x, y, 0), new Quaternion(0,0,0,0));
                cellMatrix[y][x].GetComponent<Cell>().setCell( new Cell(x, y, a));
                
               
            }

        }


        for (int y = 0; y < sizeY; y++)
        {

            for (int x = 0; x < sizeX; x++)
            {

                int x1,x3;
                int y1,y3;

                x1 = (x - 1) % sizeX;
                x3 = (x + 1) % sizeX;

                y1 = (y - 1) % sizeY;
                y3 = (y + 1) % sizeY;

                if (x1 < 0)
                    x1 = sizeX - 1;

                if (y1 < 0)
                    y1 = sizeY - 1;


                GameObject[] temp = new GameObject[8]
                {
                    cellMatrix[y1][x1],cellMatrix[y1][x],cellMatrix[y1][x3],
                    cellMatrix[y][x1],      /*self*/    cellMatrix[y][x3],
                    cellMatrix[y3][x1],cellMatrix[y3][x],cellMatrix[y3][x3]
                };

                cellMatrix[y][x].GetComponent<Cell>().setNeighbour(temp);

            }

        }

        for(int i= 0;i<numberOfCycles;i++)
        {
            checkAllCells();
        }



    }

    // Update is called once per frame
    void Update()
    {

       
        
    }


    void checkAllCells()
    {
        for(int y=0;y<sizeY;y++)
        {
            for(int x=0;x<sizeX;x++)
            {
                cellMatrix[y][x].GetComponent<Cell>().checkState(Life,Death);

            }
        }

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                cellMatrix[y][x].GetComponent<Cell>().updt();
              

            }
        }

    }
}


/*  for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {

                if (i != 0 && j != 0)
                {
                    int _y = (this.y + i) % matrix.Length;
                    int _x = (this.x + j) % matrix[0].Length;

                    if (_y < 0)
                        _y = matrix.Length - 1;

                    if (_x < 0)
                        _x = matrix[0].Length - 1;


                    if (matrix[_y][_x].GetComponent<Cell>().alive)
                    {

                        count++;
                        //Debug.Log("X: " + _x + "Y: " + _x + "Alive: " + matrix[_y][_x].alive + "count: " + count);
                    }
                }


            }
        }
*/