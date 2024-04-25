using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed = 100f; //meme speed que rota cube
    public float maxRotationUp = 45; //45 degres
    public float maxRotationDown = 45;
    public Vector3 axis = Vector3.right; //axe X
    public GameObject targetPlayCube; //target le cube


    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        float rotationChange = speed * Time.deltaTime * verticalInput;

        Vector3 targetPosition = targetPlayCube.transform.position;

        transform.RotateAround(targetPosition, axis, rotationChange);

        float currentRotationX = transform.localEulerAngles.x;

        //gestion angle max
        if (currentRotationX > 180.0f)
        {
            currentRotationX -= 360.0f;
        }

        float clampedRotationX = Mathf.Clamp(currentRotationX, -maxRotationDown, maxRotationUp);

        transform.localEulerAngles = new Vector3(clampedRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);

        //lock la cam
        transform.LookAt(targetPosition);
    }
}
