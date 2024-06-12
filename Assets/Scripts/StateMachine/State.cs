/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
*/
using System;
using System.Collections.Generic;
using UnityEngine;



public class State 
{
    public Creature owner;
    public List<Change> changes;
    public List<Behaviour> behaviours;

    public State(Creature owner, List<Change> changes, List<Behaviour> behaviours)
    {
        this.owner = owner;
        this.changes = changes;
        this.behaviours = behaviours;
    }

    public void Start()
    {
        foreach (Change change in changes)
        {
            change.condition.conditionMet.AddListener( () => { owner.changeState(change.toWhat);
            });
        }
        foreach (Behaviour behaviour in behaviours)
        {
            behaviour.SetOwner(owner);
            behaviour.SetUp();
        }
    }

    private void ChangeState(Change change)
    {
        owner.changeState(change.toWhat);
    }
    public void Execute()
    {
        foreach(Behaviour behaviour in behaviours)
        {
            behaviour.Execute();
        }
        foreach (Change change in changes)
        {
            change.condition.Execute();
        }
    }
}
