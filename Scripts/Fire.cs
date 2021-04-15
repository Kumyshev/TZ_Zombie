using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public Setting settingGame;


    [HideInInspector]
    public bool isFire;

    public Transform fire_spawn;

    public Bullet bullet;

    float nextFireTime = 1.5f;


    void Update()
    {
        if (isFire&&Time.time>nextFireTime)
        {
            nextFireTime = Time.time + settingGame.FiringSpeed;

            Shooting();
            
        }

    }

    private void Shooting()
    {
        Bullet new_bullet = Instantiate(bullet, fire_spawn.position, fire_spawn.rotation) as Bullet;

        Rigidbody rb = new_bullet.GetComponent<Rigidbody>();

        rb.AddForce(fire_spawn.forward * settingGame.BulletForce, ForceMode.Impulse);

    }
}
