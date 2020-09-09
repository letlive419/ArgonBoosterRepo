using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("meters per second")] [SerializeField] float Speed = 4f;
    [Tooltip("meters")] [SerializeField] float xMeters = 5f;
    [Tooltip("meters")] [SerializeField] float yMeters = 5f;

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
        float pitchDueToPosition;
        transform.localRotation = Quaternion.Euler(0f,0f,0f);
    }
}
