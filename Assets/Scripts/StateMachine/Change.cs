
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeData", menuName = "ScriptableObjects/ChangeData", order = 1)]
public class Change : ScriptableObject
{
    public string toWhat;
    public Condition condition = new IsAttackedCondition();

    public Change(string toWhat, Condition condition)
    {
        this.toWhat = toWhat;
        this.condition = condition;
    }
}
