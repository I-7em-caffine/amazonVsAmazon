using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHover : MonoBehaviour
{
    public GameObject cameraObject;

    //INPUTS
    float horizontal;
    float vertical;
    float rotate; //QE ROTATION NOT IMPLEMENTED
    float mouseRotateX;
    float mouseRotateY;
    float mouseWheel;
    bool sprinting;

    //MOVE
    Vector3 move_Vertical;
    Vector3 move_Horizontal;
    Vector3 move_Height;
    Vector3 moveTotal;

    //CLAMPING TRANSFORMS
    public GameObject bound01;
    public GameObject bound02;

    //ROTATE
    Vector3 pivot;
    float smoothRotationX;
    float smoothRotationY;
    float rotateVelocity;
    [SerializeField]
    float smoothRotateTime;

    //INPUT SPEEDS
    float cameraMoveSpeed = 100;
    float cameraSprintSpeed = 200;
    [SerializeField]
    private float cameraRotateSpeed;
    [SerializeField]
    private float cameraZoomSpeed;

    //ZOOM
    float zoomVelocity;
    float smoothZoom;
    [SerializeField]
    float smoothZoomTime;

    void Update()
    {
        //INPUT CHECK
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseRotateX = Input.GetAxis("Mouse X");
        mouseRotateY = Input.GetAxis("Mouse Y");
        mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        sprinting = Input.GetButton("Sprint");

        //MOVEMENT DIRECTIONS
        move_Horizontal = (transform.right * horizontal) * cameraMoveSpeed;
        move_Vertical = (transform.forward * vertical) * cameraMoveSpeed;
        moveTotal = move_Vertical + move_Horizontal;
        //MOVEMENT
        transform.position += moveTotal * Time.deltaTime;

        //MOVEMENT CLAMPING
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bound01.transform.position.x, bound02.transform.position.x),
            Mathf.Clamp(transform.position.y, bound01.transform.position.y, bound02.transform.position.y), 
            Mathf.Clamp(transform.position.z, bound01.transform.position.z, bound02.transform.position.z));

        //ROTATION PIVOT POINT
        RaycastHit pivotRay;
        Ray ray = Camera.main.ScreenPointToRay(cameraObject.transform.forward * 250);
        Physics.Raycast(ray, out pivotRay);
        pivot = ray.origin;
        //SMOOTH ROTATION INPUT
        smoothRotationX = Mathf.SmoothDamp(smoothRotationX, mouseRotateX, ref rotateVelocity, smoothRotateTime);
        smoothRotationY = Mathf.SmoothDamp(smoothRotationY, mouseRotateY, ref rotateVelocity, smoothRotateTime);
        //ROTATION
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(pivot, Vector3.up, smoothRotationX * cameraRotateSpeed * Time.deltaTime);
            //NEED TO CODE Y ROTATION
        }

        //ZOOM  
        smoothZoom = Mathf.SmoothDamp(smoothZoom, mouseWheel, ref zoomVelocity, smoothZoomTime);
        move_Height = (cameraObject.transform.forward * smoothZoom) * cameraZoomSpeed;
        transform.position += move_Height * Time.deltaTime;

        //SPRINT
        if (sprinting) { cameraMoveSpeed = cameraSprintSpeed; }
        else { cameraMoveSpeed = 100; }
    }

    void FixedUpdate()
    {

    }


}
