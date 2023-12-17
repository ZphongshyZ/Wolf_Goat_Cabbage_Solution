using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : ObjectInGame
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.state = "A";
    }
}
