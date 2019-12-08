using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensitivity = 10;
    public Transform target;
    public float dstFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    public float zoomSpeed = 4f;
    public float minZoom = 1f;
    public float maxZoom = 3f;
    public float currentZoom = 2f;

    float yaw;
    float pitch;

    private void Start()//on start
    {
        if (lockCursor)//we look for cursor and we make it locked and invisible
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    private void Update()//on update
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;//we check for zoom through mouse scroll wheel
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    private void LateUpdate()//on late update
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;//we get the axis of the mouse x,y location
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);//we make camera not to look beyond min and max pitch values

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);//we get the zoom in and out values
        transform.eulerAngles = currentRotation;//we rotate camera

        transform.position = target.position - transform.forward * currentZoom;//we transform the camera

    }
}
