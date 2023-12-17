using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : ObjectInGame
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.state = "A";
    }
}
