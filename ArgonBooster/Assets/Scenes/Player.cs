using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("meters per second")] [SerializeField] float Speed = 30f;
    [Tooltip("meters")] [SerializeField] float xMeters = 12f;
    [Tooltip("meters")] [SerializeField] float yMeters = 6f;
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float controlPitchFactor = -1f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -20f;

    float horizontalThrow, verticalThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPosition();
        ProcessRotation();
    }

    private void ProcessPosition()
    {
         horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
         verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffSet = horizontalThrow * Speed * Time.deltaTime;
        float rawX = transform.localPosition.x + xOffSet;
        float newX = Mathf.Clamp(rawX, -xMeters, xMeters);

        float yOffSet = verticalThrow * Speed * Time.deltaTime;
        float rawY = transform.localPosition.y + yOffSet;
        float newY = Mathf.Clamp(rawY, -yMeters, yMeters);

        print(horizontalThrow);

        transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = verticalThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
}
