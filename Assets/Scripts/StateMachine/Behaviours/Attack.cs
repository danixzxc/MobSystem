using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "Behaviour", menuName = "ScriptableObjects/AttackingBehaviour", order = 1)]
public class Attacking : Behaviour
{

    private bool playerInSightRange;
    private bool playerInAttackRange;
    private bool canAttack;

    private float attackTime;

    //singleton manager will pass it 
    private Transform player; 
    public LayerMask  whatIsPlayer;

    //this behaviour
    public float timeBetweenAttacks;
    public GameObject projectile;
    public float attackRange;


    //TODO удалить это
    public override void SetUp()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        attackTime = timeBetweenAttacks;
    }


    public override void Execute()
    {
        playerInSightRange = Physics.CheckSphere(owner.transform.position, owner.sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(owner.transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void AttackPlayer()
    {
        //Debug.Log("Attacking player");

        //Make sure enemy doesn't move
       owner.agent.SetDestination(player.transform.position);
        attackTime += Time.deltaTime;
        if (attackTime == timeBetweenAttacks)
        {
            canAttack = true;
        }
        if (canAttack)
        {
            Rigidbody rb = Instantiate(projectile, owner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(owner.transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(owner.transform.up * 8f, ForceMode.Impulse);
            ///End of attack code
            attackTime = 0f;
            canAttack = false;
        }
    }

    public void TakeDamage(int damage)
    {
        owner.health -= damage;

        if (owner.health <= 0) owner.Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(owner.gameObject);
    }





}
