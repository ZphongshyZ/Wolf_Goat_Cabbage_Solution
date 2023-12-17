using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateA : State
{
    protected override void LoadComponents()
    {
        this.wolfLocation = GameObject.Find("Wolf_LocationA").transform;
        this.goatLocation = GameObject.Find("Goat_LocationA").transform;
        this.cabbageLocation = GameObject.Find("Cabbage_LocationA").transform;
    }
}
