using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flightControler : MonoBehaviour
{
    public float fSpeed = 25f, sSpeed = 7.5f, hSpeed = 5f;
    private float aFSpeed, aSSpeed, aHSpeed;
    private float fAcceleration = 2.5f, sAcceleration = 2f, hAcceleration = 2f;

    public float lookAt = 90f;
    private Vector2 lookInput, screenCentre, mouseDist;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        screenCentre.x = Screen.width * .5f;
        screenCentre.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDist.x = (lookInput.x - screenCentre.x) / screenCentre.x;
        mouseDist.y = (lookInput.y - screenCentre.y) / screenCentre.y;

        mouseDist = Vector2.ClampMagnitude(mouseDist, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDist.y * lookAt * Time.deltaTime, mouseDist.x * lookAt * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        aFSpeed = Mathf.Lerp(aFSpeed, Input.GetAxisRaw("Vertical") * fSpeed, fAcceleration * Time.deltaTime);
        aSSpeed = Mathf.Lerp(aSSpeed, Input.GetAxisRaw("Horizontal") * sSpeed, sAcceleration * Time.deltaTime);
        aHSpeed = Mathf.Lerp(aHSpeed, Input.GetAxisRaw("Hover") * hSpeed, hAcceleration * Time.deltaTime);

        transform.position += transform.forward * aFSpeed * Time.deltaTime;
        transform.position += (transform.right * aSSpeed * Time.deltaTime) + (transform.up * aHSpeed * Time.deltaTime);
    }
}
