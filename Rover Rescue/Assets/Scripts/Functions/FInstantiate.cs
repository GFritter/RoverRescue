using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Functions/Instantiate")]
public class FInstantiate : Function
{
    public VInt x, y, z;
    public GameObject prefab;

    public override void Trigger()
    {
        Instantiate(prefab, new Vector3(x.value, y.value, z.value), Quaternion.identity);
    }
}
