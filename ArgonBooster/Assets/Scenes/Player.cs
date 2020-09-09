using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("meters per second")] [SerializeField] float xSpeed = 4f;
    [Tooltip("meters")] [SerializeField] float xMeters = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffSet = horizontalThrow * xSpeed * Time.deltaTime;
        float rawX = transform.localPosition.x + xOffSet;
        float newX = Mathf.Clamp(rawX, -xMeters, xMeters);
        print(horizontalThrow);

        transform.localPosition = new Vector3(newX, transform.localPosition.y, transform.localPosition.z);
    }
}
