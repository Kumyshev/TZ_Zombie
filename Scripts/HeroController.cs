using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour
{

    
    public Camera m_camera;
    public NavMeshAgent navAgent;

    private Animator animator;

    private bool Run = false;

    private Vector3 lastPos;

    public Transform gunInHend;
    private bool fireState = false;

    public Fire fire;

    public ParticleSystem particle;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        
        navAgent.speed = fire.settingGame.HeroSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);


        float ray_length;

        if (plane.Raycast(ray, out ray_length))
        {
            var look_point = ray.GetPoint(ray_length);

            transform.LookAt(new Vector3(look_point.x, transform.position.y, look_point.z));

            gunInHend.LookAt(look_point);
        }


        if (Run)
        {
            if (transform.position == lastPos)
            {
                animator.SetBool("run", false);
            }
            else
            {
                animator.SetBool("run", true);
            }

            lastPos = transform.position;
        }

        if (!fireState)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Run = true;

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    navAgent.SetDestination(hit.point);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("fire", true);

                particle.Play();

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                }
                fire.isFire = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                particle.Stop();
                animator.SetBool("fire", false);
                fire.isFire = false;

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tower")
        {
            fireState = true;
        }
    }
}
