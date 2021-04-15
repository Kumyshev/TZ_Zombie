using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegdollOn : MonoBehaviour
{

    

    Rigidbody[] rigidbodies;

    bool isRegdoll = false;


    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();

        stateKinematic(true);
    }

    private void stateKinematic(bool v)
    {
        foreach (var rb in rigidbodies) 
        {
            rb.isKinematic = v;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (!isRegdoll && collision.gameObject.tag == "bullet") 
    //    {
    //        animator.enabled = false;
    //        isRegdoll = true;

    //        stateKinematic(false);
    //    }
    //}


    public void GetHit() 
    {
        animator.enabled = false;

        stateKinematic(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
