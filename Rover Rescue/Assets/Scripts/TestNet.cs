using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNet : MonoBehaviour
{
    

   public Scr_PetriNet RedeNova;

    // Start is called before the first frame update
    void Start()
    {
        //initNet();
        RedeNova.ClearAllPlaces();

        for (int i = 0; i < 30; i++) 
        RedeNova.getPlaceID(1).addToken(new Token());

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            RedeNova.getPlaceID(10).addToken(new Token());
        }

        if(Input.anyKeyDown)
        {
            RedeNova.getPlaceID(0).addToken(new Token());
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        RedeNova.execCycle();
    }

    

}
