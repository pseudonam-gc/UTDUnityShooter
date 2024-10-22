using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;

    public float clampMin = -90f;
    public float clampMax = 90f;

    // Start is called before the first frame update
    void Start()
    {
        // hides, locks cursor
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clampMin, clampMax);
        yRotation += mouseX;   
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
