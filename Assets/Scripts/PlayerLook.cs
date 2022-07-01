using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera fppCamera;
    public Camera tppCamera;
    public bool isFirstPerson = true;

    private float xRotation = 0f;

    public float xSensitivity = 8f;
    public float ySensitivity = 8f;

    public float minLookAngle = -80f;
    public float maxLookAngle = 80f;

    void Start()
    {
        SetCamera();
    }

    public void SetCamera() {
        if (isFirstPerson)
        {
            fppCamera.enabled = true;
            tppCamera.enabled = false;
        }
        else
        {
            fppCamera.enabled = false;
            tppCamera.enabled = true;
        }
    }

    public void SwitchCamera()
    {
        isFirstPerson = !isFirstPerson;
        SetCamera();
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);

        fppCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
