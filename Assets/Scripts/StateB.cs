using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateB : State
{
    protected override void LoadComponents()
    {
        this.wolfLocation = GameObject.Find("Wolf_LocationB").transform;
        this.goatLocation = GameObject.Find("Goat_LocationB").transform;
        this.cabbageLocation = GameObject.Find("Cabbage_LocationB").transform;
    }
}
