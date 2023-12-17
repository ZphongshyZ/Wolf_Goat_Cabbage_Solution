using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : Phong
{
    //Game Obj
    public Man man;
    public Wolf wolf;
    public Goat goat;
    public Cabbage cabbage;
    public List<ObjectInGame> gameObjects;
    public List<ObjectInGame> solution;
    public List<string[]> State = new List<string[]>();

    protected override void Start()
    {
        this.State.Clear();
        this.gameObjects.Clear();
        this.gameObjects.Add(this.wolf);
        this.gameObjects.Add(this.goat);
        this.gameObjects.Add(this.cabbage);
        this.State.Add(new string[] {this.man.state, this.wolf.state, this.goat.state, this.cabbage.state});
    }

    private void Update()
    {
        this.Move();   
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.man = GameObject.Find("Man").GetComponent<Man>();
        this.wolf = GameObject.Find("Wolf").GetComponent<Wolf>();
        this.goat = GameObject.Find("Goat").GetComponent<Goat>();
        this.cabbage = GameObject.Find("Cabbage").GetComponent<Cabbage>();
    }

    public void Move()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.man.isRunning = true;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            this.Search_Obj_Can_On_Boat();
            this.Search_Next_Move();
        }
    }

    public void AutoMove()
    {
        this.man.isRunning = true;
    }

    public bool Is_Valid()
    {
        bool goat_eats_cabbage = (this.goat.state == this.cabbage.state) && (this.goat.state != this.man.state);
        bool wolf_eats_goat = (this.wolf.state == this.goat.state) && (this.wolf.state != this.man.state);

        bool invalid = goat_eats_cabbage || wolf_eats_goat;
        return !invalid;
    }

    public void CheckValid()
    {
        if (this.Is_Valid()) return;
        else Debug.Log("You Lose");
    }

    public void Search_Obj_Can_On_Boat()
    {
        foreach (ObjectInGame thing in gameObjects)
        {
            if(thing.state == this.man.state)
            {
                solution.Add(thing);
            }
        }
    }
    
    public void Search_Next_Move()
    {
        foreach(ObjectInGame thing in solution)
        {
            string oldState = thing.state;
            string oldState2;

            if (thing.state == "A") thing.state = "B";
            else thing.state = "A";

            this.man.state = thing.state;

            if(Is_Valid() == false)
            {
                thing.state = oldState;
                this.man.state = oldState;
            }
            else
            {
                oldState2 = thing.state;
                thing.state = oldState;
                if (Is_Valid() == true)
                {
                    string[] newState2 = new string[] { this.man.state, this.wolf.state, this.goat.state, this.cabbage.state };
                    bool b = CheckState(newState2);
                    if (b == true)
                    {
                        this.State.Add(newState2);
                        this.solution.Clear();
                        this.AutoMove();
                        return;
                    }
                    else
                    {
                        thing.state = oldState2;
                        string[] newState = new string[] { this.man.state, this.wolf.state, this.goat.state, this.cabbage.state };
                        bool a = CheckState(newState);
                        if (a == true)
                        {
                            this.State.Add(newState);
                            thing.isOnBoat = true;
                            this.solution.Clear();
                            this.AutoMove();
                            return;
                        }
                        else return;
                    } 
                }
                else
                {
                    thing.state = oldState2;
                    string[] newState3 = new string[] { this.man.state, this.wolf.state, this.goat.state, this.cabbage.state };
                    bool c = CheckState(newState3);
                    if (c == true)
                    {
                        this.State.Add(newState3);
                        thing.isOnBoat = true;
                        this.solution.Clear();
                        this.AutoMove();
                        return;
                    }
                    else
                    {
                        thing.state = oldState;
                    }    
                }    
            }
        }
    }

    public bool CheckState(string[] state)
    {
        int check;
        int count = 0;
        for (int i = 0; i < State.Count; i++)
        {
            check = 0;
            Debug.Log(i + ": ");
            for (int j = 0; j < State[i].Length; j++)
            {
                if (state[j] == State[i][j])
                {
                    Debug.Log(state[j] + " == " + this.State[i][j]);
                    check++;
                    Debug.Log(check);
                }
                else
                {
                    Debug.Log(state[j] + " != " + this.State[i][j]);
                    Debug.Log(check);
                }

                if (check == 4)
                {
                    count++;
                    Debug.Log("Not Valid");
                    return false;
                }
            }
        }
        Debug.Log("Valid");
        return true;
    }    
}
