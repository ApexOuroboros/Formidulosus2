using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSens = 2.0f;
    float camVertRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSens;
        float inputY = Input.GetAxis("Mouse Y") * mouseSens;

        camVertRot -= inputY;
        camVertRot = Mathf.Clamp(camVertRot, -90f, 90f);
        transform.localEulerAngles = Vector3.right * camVertRot;

        player.Rotate(Vector3.up * inputX);
    }
}
