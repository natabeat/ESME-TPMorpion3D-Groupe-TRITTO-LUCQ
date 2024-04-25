using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayCube : MonoBehaviour
{

    public float speed = 100f;
    public Vector3 axis = Vector3.up; //axe Y

    // Update is called once per frame
    void Update()
    {
       
        float keyboardInput = Input.GetAxis("Horizontal");
        float resultingSpeed = speed * Time.deltaTime * keyboardInput;

        // Tourne le cube autour de l'axe vertical
        transform.Rotate(axis * resultingSpeed);
    }
}
