using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    //Variables
    [SerializeField] float swayIntensity = 20.0f;
    Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Set startRotation to weapon's current rotation
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WeaponSway()
    {
        //Get mouse input
        float swayX = Input.GetAxis("Mouse X");
        float swayY = Input.GetAxis("Mouse Y");

        //Set sway xAngle and intensity
        Quaternion xAngle = Quaternion.AngleAxis(swayX * -1.25f, Vector3.up);

        //Set sway yAngle and intensity
        Quaternion yAngle = Quaternion.AngleAxis(swayY * -1.25f, Vector3.right);

        //Set sway rotation
        Quaternion targetRotation = startRotation * xAngle * yAngle;

        //Shake weapon according to sway rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swayIntensity);

    }
}
