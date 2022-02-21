using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseHorizontal;
    private float mouseVertical;
    public float mouseSensitivity;

    float temp = 0;
    public Transform playerTransform;

    private void Start()
    {
        //transform.localRotation = Quaternion.Euler(0, 0, 0);
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        ////Getting Mouse Input
        GetInputFunc();


        ////Horizontal Look (Rotatating player instead of rotating only camera)
        playerTransform.Rotate(Vector3.up * mouseHorizontal);


        //Vertical Look (Rotating only camera instead of player)
        temp -= mouseVertical;
        temp = Mathf.Clamp(temp, -90f, 90f);
        transform.localRotation = Quaternion.Euler(temp, 0f, 0f);

    }

    ////Simple Function to get player mouse input
    public void GetInputFunc()
    {
        mouseHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseVertical = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
}
