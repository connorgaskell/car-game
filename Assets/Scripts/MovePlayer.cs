using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Wheel {
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public enum Axel {
    Front,
    Back
}

public class MovePlayer : MonoBehaviour {
    [SerializeField]
    private float maxAcceleration = 40.0f;

    [SerializeField]
    private float turnSensitivity = 1.0f;

    [SerializeField]
    private float maxSteerAngle = 45.0f;

    [SerializeField]
    private Vector3 centerOfMass;

    [SerializeField]
    private List<Wheel> wheels;

    private float inputX, inputY;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    void Update() {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        RotateWheels();
    }

    void LateUpdate() {
        Move();
        Turn();
    }

    private void Move() {
        foreach(Wheel wheel in wheels) {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500.0f * Time.deltaTime;
            
        }
    }

    private void Turn() {
        foreach(Wheel wheel in wheels) {
            if(wheel.axel == Axel.Front) {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f);
            }
        }
    }

    private void RotateWheels() {
        foreach(Wheel wheel in wheels) {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }
}
