using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MouseLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform playerBody;
    [SerializeField] float xRotation = 0f;
    [SerializeField] GameObject guide;

    [Header("Sensitivity Settings")]
    [SerializeField] float mouseSensitivity = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        guide.transform.rotation = transform.rotation;
    
    }
}
