using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IsAttackingCondition", menuName = "ScriptableObjects/Condition", order = 1)]
public class IsAttackedCondition : Condition
{
    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MeetCondition();
        }
    }

   
}
