using UnityEngine;
using UnityEngine.Events;



public abstract class Condition : ScriptableObject
{
    /*protected delegate void MeetCondition();
    public event MeetCondition conditionMet;
     */
    public UnityEvent conditionMet = new UnityEvent();
    protected void MeetCondition()
    {
    conditionMet.Invoke();
    }
    public abstract void Execute();
}
