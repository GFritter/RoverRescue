using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Functions/Trigger Light")]
public class FTriggerLight : Function
{

    public VBool lightEnabler;

    public override void Trigger()
    {
        lightEnabler.value = !lightEnabler.value;
    }
}
