using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.UI.GridLayoutGroup;

[Serializable]
public class Creature : MonoBehaviour
{
    private Dictionary<string, State> states = new Dictionary<string, State>();

    [SerializeField]
    private List<StatesEntry> entries = new List<StatesEntry>();
    
    [SerializeField]
    private string startingState;
    
    private State currentState;


    [SerializeField]
    public float health;
    [SerializeField]
    public float sightRange;
    [SerializeField]
    public NavMeshAgent agent;


    public void ListToDictionary()
    {
        states.Clear();
        foreach (StatesEntry entry in entries)
        {
            states.Add(entry.key, new State(this, entry.changes, entry.behaviours));
        }
    }

    void Start()
    {
        ListToDictionary();

        currentState = states[startingState];

        // list прокидывается в инспекторе а не тут создается
        foreach (var state in states.Values)
        {
            state.owner = this;
            state.Start();
        }
    }

     void Update()
    {
        currentState.Execute();
    }

    public void changeState(string key)
    {
        currentState = states[key];
    }
    public void lookAt(Vector3 target)
    {
        this.transform.eulerAngles = new Vector3(0, 
            Mathf.Atan2(target.x - this.transform.position.x,
            target.z - this.transform.position.z) * Mathf.Rad2Deg, 0);

    }
}
