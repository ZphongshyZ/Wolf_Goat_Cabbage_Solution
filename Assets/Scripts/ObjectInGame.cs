using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInGame : Phong
{
    //State
    public State startState;
    public State goalState;

    //Gameobj
    public Transform objGame;
    public Transform boat;

    //Properties
    public string state;
    public bool isOnBoat = false;
    float x;
    float y;

    protected override void Start()
    {
        base.Start();
        this.CheckStateLocation();
    }

    public virtual void Update()
    {
        this.CheckStateLocation();
        //this.CheckState();
        this.OnBoat();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.objGame = this.transform;
        this.boat = GameObject.Find("Boat").transform;
        this.startState = GameObject.Find("State A").GetComponentInParent<StateA>();
        this.goalState = GameObject.Find("State B").GetComponentInParent<StateB>();
    }

    public virtual void OnBoat()
    {
        if (this.gameObject.name == "Man") return;
        if (this.isOnBoat == true)
        {
            float newX = this.boat.transform.position.x;
            float newY = this.boat.transform.position.y;
            this.transform.position = new Vector2(newX, newY);
        }    
        else
        {
            this.transform.position = new Vector2(x, y);
        }    
    }    

    public virtual void CheckState()
    {
        if (this.transform.position.x < 0)
        {
            this.state = "B";
        }
        else this.state = "A";
    }    

    public virtual void CheckStateLocation()
    {
        if(this.state == "A")
        {
            if (transform.name == "Wolf")
            {
                this.x = this.startState.wolfLocation.position.x;
                this.y = this.startState.wolfLocation.position.y;
            }
            else if (transform.name == "Goat")
            {
                this.x = this.startState.goatLocation.position.x;
                this.y = this.startState.goatLocation.position.y;
            }
            else if (transform.name == "Cabbage")
            {
                this.x = this.startState.cabbageLocation.position.x;
                this.y = this.startState.cabbageLocation.position.y;
            }
        }

        if(this.state == "B")
        {
            if (transform.name == "Wolf")
            {
                this.x = this.goalState.wolfLocation.position.x;
                this.y = this.goalState.wolfLocation.position.y;
            }
            else if (transform.name == "Goat")
            {
                this.x = this.goalState.goatLocation.position.x;
                this.y = this.goalState.goatLocation.position.y;
            }
            else if (transform.name == "Cabbage")
            {
                this.x = this.goalState.cabbageLocation.position.x;
                this.y = this.goalState.cabbageLocation.position.y;
            }
        }
    }

    public virtual void CarryBoat()
    {
        if (this.gameObject.name == "Man") return;
        this.isOnBoat = !isOnBoat;
    }

    public virtual void OnMouseDown()
    {
        this.CarryBoat();
    }
}
