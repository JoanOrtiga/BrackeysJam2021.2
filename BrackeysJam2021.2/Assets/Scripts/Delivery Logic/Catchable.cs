using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Catchable : MonoBehaviour
{
    //public string Name;

    public virtual string GetName()
    {
        return "Catcheable";
    }
}
