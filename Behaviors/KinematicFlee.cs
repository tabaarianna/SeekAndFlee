using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicFlee : MonoBehaviour
{
    private Vector3 linearVelocity;
    private float angularVelocity;
    public float maxSpeed;
    public Transform target;

    void Update()
    {

        SteeringOutput steering = getSteering();
        transform.position += steering.linearVelocity * Time.deltaTime;
    }

    float newOrientation(float currentOrientation, Vector3 velocity)
    {

        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(velocity.x, velocity.z);
           
        }
        else
        {
            return currentOrientation;
        }
    }

    SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();


        result.linearVelocity = target.position - this.transform.position;


        result.linearVelocity = -result.linearVelocity.normalized * maxSpeed;


        float angle = newOrientation(transform.eulerAngles.y, result.linearVelocity);
        angle *= Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0, angle, 0);

        result.angularVelocity = 0;
        return result;
    }

}