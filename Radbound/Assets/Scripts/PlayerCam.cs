using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public bool WantInput = true;

    public Transform orientation;

    float xRoatation;
    float yRoatation;

    // Start is called before the first frame update
    private void Start()
    {

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        GetInputSetRotation();


    }
    public void GetInputSetRotation()
    {
        if (WantInput)
        {
            //get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
            yRoatation += mouseX;
            xRoatation -= mouseY;
            //lock look up and down
            xRoatation = Mathf.Clamp(xRoatation, -90f, 90f);
            //rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRoatation, yRoatation, 0);
            orientation.rotation = Quaternion.Euler(0, yRoatation, 0);

        }
    }
}