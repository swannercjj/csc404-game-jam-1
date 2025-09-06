using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            //transform.rotation = toRotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }


    }
}

