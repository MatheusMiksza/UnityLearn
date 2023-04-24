using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 0;
    public float rotationSpeed;
    public float verticalInput;
    public float hotrizontalInput;
    public float offX;
    public float offY;
    public float offZ;
    private Vector3 offset;
    private GiroHelice giroHelice;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        giroHelice = new GiroHelice();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hotrizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical") * -1;
        if(speed <=20 && hotrizontalInput > 0)
           speed = speed + hotrizontalInput;
        if(speed > 0 && hotrizontalInput < 0)
            speed = speed + hotrizontalInput;
        offZ = Time.deltaTime * speed;

        offY = 0;
        offX = 0;
        offset = new Vector3(offX,offY,offZ);
        // get the user's vertical input
       

        // move the plane forward at a constant rate
        transform.Translate(offset);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);

        if (transform.position.z < 0)
        {
            transform.Translate(startPosition.x - transform.position.x, startPosition.y- transform.position.y, 174 * -1);
        }
    }
}
