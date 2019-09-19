using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{

    public VInt ammo;
    public Light l;
    public Text t;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        l.range = ammo.value/2;
        t.text = ammo.value.ToString();
        
    }
}
