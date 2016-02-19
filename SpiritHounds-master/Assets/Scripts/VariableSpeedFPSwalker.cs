using UnityEngine;
using System.Collections;

public class VariableSpeedFPSwalker : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed = 10;
    [SerializeField]
    private float backwardSpeed = 5;
    [SerializeField]
    private float strafeSpeed = 8;

    void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Step1: Get your input values
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Step 2: Limit the movement on angles and then multiply those results
        // by their appropriate speed variables
        float percentofpercent = Mathf.Abs(horizontal) + Mathf.Abs(vertical) - 1;
        if (percentofpercent > 0.1f)
        {
            // if we're here, then we're not moving in a straight line
            // my math here might be kinda confusing and sloppy...so don't look!
            percentofpercent = percentofpercent * 10000;
            percentofpercent = Mathf.Sqrt(percentofpercent);
            percentofpercent = percentofpercent / 100;
            float finalMultiplier = percentofpercent * .25f;
            horizontal = horizontal - (horizontal * finalMultiplier);
            vertical = vertical - (vertical * finalMultiplier);
        }

        if (vertical > 0)
            vertical = vertical * forwardSpeed;
        else if (vertical < 0)
            vertical = vertical * backwardSpeed;

        horizontal = horizontal * strafeSpeed;

        // Step 3: Derive a vector on which to travel, based on the combined
        // influence of BOTH axes (ignoring any y movement)
        Vector3 tubeFinalVector = transform.TransformDirection(new Vector3(horizontal, GetComponent<Rigidbody>().velocity.y, vertical));

        // Step 4: Apply the final movement in world space
        GetComponent<Rigidbody>().velocity = tubeFinalVector;
    }
}
