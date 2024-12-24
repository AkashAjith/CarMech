using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //Rigidbody rb; 

    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public Transform frontLeftTransform;
    public Transform frontRightTransform;
    public Transform rearLeftTransform;
    public Transform rearRightTransform;

    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 30f;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(0,0,1);
        }
    }    

    private void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;

        frontLeftWheel.motorTorque = motor;
        frontRightWheel.motorTorque = motor;

        UpdateWheelPoses();
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheel, frontLeftTransform);
        UpdateWheelPose(frontRightWheel, frontRightTransform);
        UpdateWheelPose(rearLeftWheel, rearLeftTransform);
        UpdateWheelPose(rearRightWheel, rearRightTransform);
    }

    private void UpdateWheelPose(WheelCollider _colli, Transform _transf)
    {
        Vector3 pos;
        Quaternion quat;
        _colli.GetWorldPose(out pos, out quat);

        _transf.position = pos;
        _transf.rotation = Quaternion.Euler(0,quat.eulerAngles.y, 90);

        /*if(_colli.steerAngle!=0)
        {
            _transf.rotation = new Quaternion(_colli.steerAngle,0,0,0);
        }*/
    }
}