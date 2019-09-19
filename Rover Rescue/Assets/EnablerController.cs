using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablerController : MonoBehaviour
{

    public Light l;
    public VBool enabler;

    // Update is called once per frame
    void Update()
    {
        l.enabled = enabler.value;
       
        if(enabler.value)
        {
            enabler.value = false;
        }
        
    }
}
