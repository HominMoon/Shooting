using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controllSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controllPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] InputAction movement;

    float xVal;
    float yVal;

    // Update is called once per frame
    void Update()
    {   ProcessRotation();
        ProcessTranslation();
        
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlValue = yVal * controllPitchFactor;

        float pitch = pitchDueToPosition * pitchDueToControlValue;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xVal * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xVal = Input.GetAxis("Horizontal");
        yVal = Input.GetAxis("Vertical");

        float xOffset = xVal * Time.deltaTime * controllSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yVal * Time.deltaTime * controllSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampXPos, clampYPos, transform.localPosition.z);
    }




    // float horizontalThrow = movement.ReadValue<Vector2>().x;
    // float verticalThrow = movement.ReadValue<Vector2>().y;

    //[SerializeField] InputAction movement;

    // private void OnEnable() {
    //     movement.Enable();
    // }
    // private void OnDisable() {
    //     movement.Disable();
    // }
}
