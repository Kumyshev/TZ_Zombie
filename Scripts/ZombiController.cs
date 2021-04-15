using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiController : MonoBehaviour
{
    public Transform booty;
    public NavMeshAgent navAgent;

    public float health = 10;

    Rigidbody[] rigidbodies;

    private Animator animator;

    [SerializeField]
    private Collider main_collider;
    [SerializeField]
    private Rigidbody main_rb;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();

        stateKinematic(true);
    }
    private void stateKinematic(bool v)
    {
        main_collider.enabled = v;

        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = v;
        }
        main_rb.isKinematic = !v;
    }

    public void GetHit(float damage)
    {
        animator.enabled = false;

        stateKinematic(false);

        health += damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            navAgent.SetDestination(booty.position);
        }
        else 
        {
            navAgent.enabled = false;
            Destroy(gameObject, 5f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet") 
        {
            GetHit(-10);
        }
    }
}
