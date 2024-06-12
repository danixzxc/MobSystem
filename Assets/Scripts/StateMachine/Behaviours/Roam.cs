using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Behaviour", menuName = "ScriptableObjects/RoamBehaviour", order = 1)]
public class Roam : Behaviour
{
    public override void Execute()
    {
        Roaming();
    }

    public override void SetUp()
    {
        throw new System.NotImplementedException();
    }

    private void Roaming()
    {
        Debug.Log("Roaming in the forest");
    }
}
