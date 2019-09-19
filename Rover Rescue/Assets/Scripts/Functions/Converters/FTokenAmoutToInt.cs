using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Functions/Token To Int")]
public class FTokenAmoutToInt : Function
{

    public Scr_Place place;
    public VInt integer;

   
    public override void Trigger()
    {
        integer.value = place.getTokenAmout();
    }

}
