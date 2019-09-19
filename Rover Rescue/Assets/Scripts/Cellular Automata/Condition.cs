using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Condition : ScriptableObject
{

    public int LessThan, MoreThan, Equal;
    public bool useEqual;

}
