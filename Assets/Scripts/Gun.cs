using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject bubblesParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootGun();
    }

    void ShootGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.Instance.ammo > 0)
            {
                GameManager.Instance.ammo -= 20f; ;
                GameObject projectile = Instantiate(bubblesParticle) as GameObject;
                projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 20;
            }
        } 
    }
}
