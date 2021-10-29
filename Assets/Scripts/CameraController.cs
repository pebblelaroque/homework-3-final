using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float sensX;

    [SerializeField]
    private float sensY;

    Camera camera;

    float mouseX;

    float mouseY;

    float multiplier = 0.01f;

    float rotY;

    float rotX;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        controls();

        camera.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotY, 0); 
    }

    void controls()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        rotY += mouseX * sensX * multiplier;
        rotX -= mouseY * sensY * multiplier;

        rotX = Mathf.Clamp(rotX, -90f, 90f);
    }
}
