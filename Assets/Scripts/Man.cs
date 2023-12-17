using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : ObjectInGame
{
    public bool isRunning = false;
    public Vector3 targetPosition;
    public float posXTarget;

    protected override void Start()
    {
        posXTarget = -3.5f;
        targetPosition = new Vector3(posXTarget, -2, 0);
    }

    private void FixedUpdate()
    {
        this.ChangeTarget();
        this.Move();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isOnBoat = true;
        this.state = "A";
    }

    public virtual void Move()
    {
        if (isRunning == false) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1f * Time.deltaTime);
    }

    public virtual void ChangeTarget()
    {
        if (transform.position == targetPosition)
        {
            posXTarget *= -1;
            targetPosition = new Vector3(posXTarget, -2, 0);
            isRunning = false;
        }
        else return;
    }    
}
