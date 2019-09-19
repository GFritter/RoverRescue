using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Functions/Switch")]
public class FSwitch : Function
{
    public VBool enabler;

    public override void Trigger()
    {
        enabler.value = !enabler.value;
    }
}
