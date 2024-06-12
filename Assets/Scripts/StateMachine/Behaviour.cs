using UnityEngine;

public abstract class Behaviour : ScriptableObject
{
    protected Creature owner;
    public abstract void Execute();
    public abstract void SetUp();

    public void SetOwner(Creature owner)
    {
        this.owner = owner;
    }
}
