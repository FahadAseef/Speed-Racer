using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRightCollider;
    [SerializeField] WheelCollider frontLeftCollider;
    [SerializeField] WheelCollider backRightCollider;
    [SerializeField] WheelCollider backLeftCollider;

    [SerializeField] float acceleration = 500f;
    [SerializeField] float breakingFrorce = 300f;

    [SerializeField] float maxTurnAngle = 15f;


    private float currentAccelaration = 0f;
    private float currentBreakingForce = 0f;

    private float currentTurnAngle = 0f;

    private void FixedUpdate()
    {
        //get forward/reverse acceleration from the vertical axis (w and s key)
        currentAccelaration = acceleration * Input.GetAxisRaw("Vertical");

        //if we are pressing space . give currentbrakeforce a value
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingFrorce;
        }
        else
        {
            currentBreakingForce = 0f;
        }

        //apply acceleration for wheels
        frontLeftCollider.motorTorque = currentAccelaration;
        frontRightCollider.motorTorque = currentAccelaration;

        //applying breaking for all wheels
        frontRightCollider.brakeTorque = currentBreakingForce;
        frontLeftCollider.brakeTorque = currentBreakingForce;
        backRightCollider.brakeTorque = currentBreakingForce;
        backLeftCollider.brakeTorque = currentBreakingForce;

        //take care of the steering
        currentTurnAngle = maxTurnAngle*Input.GetAxisRaw("Horizontal");
        frontLeftCollider.steerAngle = currentTurnAngle;
        frontRightCollider.steerAngle = currentTurnAngle;

    }



}
