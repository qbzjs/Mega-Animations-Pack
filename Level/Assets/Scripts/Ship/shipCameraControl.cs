using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipCameraControl : MonoBehaviour
{
    [SerializeField] public int sensHort;
    [SerializeField] public int sensVert;

    int lockVertMin;
    int lockVertMax;

    [SerializeField] bool invert;

    float xRotation;
    int currSliderValue;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // get input
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensHort;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensVert;

        if (invert)
            xRotation += mouseY;
        else
            xRotation -= mouseY;

        // clamp camera rotation
        xRotation = Mathf.Clamp(xRotation, 25, 25);

        // rotate the camera on the x-axis
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // rotate the player
        transform.parent.Rotate(Vector3.up * mouseX);

    }
}
