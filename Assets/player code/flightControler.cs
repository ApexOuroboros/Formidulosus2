using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flightControler : MonoBehaviour
{
    public float fSpeed = 25f, sSpeed = 7.5f, hSpeed = 5f;
    private float aFSpeed, aSSpeed, aHSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aFSpeed = Input.GetAxisRaw("Vertical") * fSpeed;
        aSSpeed = Input.GetAxisRaw("Horizontal") * sSpeed;
        aHSpeed = Input.GetAxisRaw("Hover") * hSpeed;

        transform.position += transform.forward * aFSpeed * Time.deltaTime;
        transform.position += (transform.right * aSSpeed * Time.deltaTime) + (transform.up * aHSpeed * Time.deltaTime);
    }
}
