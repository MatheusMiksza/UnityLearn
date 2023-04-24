using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controler : MonoBehaviour
{
    public float speed = 15;
    public float speedTurn = 25;
    public float rotationSpeed;
    public float verticalInput;
    public float hotrizontalInput;
    float offX;
    public float offY;
    public float offZ;
    private Vector3 offset;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        hotrizontalInput = Input.GetAxis("Horizontal_wasd");
        verticalInput = Input.GetAxis("Vertical_wasd");
        if (verticalInput < 0) hotrizontalInput = hotrizontalInput * -1;

        offZ = Time.deltaTime * speed * verticalInput;

        offY = 0;
        offX = 0;
        offset = new Vector3(offX, offY, offZ);
        // get the user's vertical input


        // move the plane forward at a constant rate
        transform.Translate(offset);

        // tilt the plane up/down based on up/down arrow keys
        if (verticalInput != 0)
            transform.Rotate(Vector3.up, Time.deltaTime * speedTurn * hotrizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            hoodCamera.enabled = !hoodCamera.enabled;
        }

        //if(transform.position.y < -100)
        //    transform.TransformDirection(startPosition.x - transform.position.x, startPosition.y, startPosition.z );


    }
}
