using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 15;
    public float speedTurn = 25;
    public float rotationSpeed;
    public float verticalInput;
    public float hotrizontalInput;
    public float offX;
    public float offY;
    public float offZ;
    private Vector3 offset;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hotrizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput < 0) hotrizontalInput = hotrizontalInput * -1;

        if (transform.rotation.z >= 90 || transform.rotation.z <= -90 )
            transform.Rotate(0,0,0);

        offZ = Time.deltaTime * speed * verticalInput;

        offY = 0;
        offX = 0;
        offset = new Vector3(offX, offY, offZ);
        // get the user's vertical input


        // move the plane forward at a constant rate
        transform.Translate(offset);

        // tilt the plane up/down based on up/down arrow keys
        if(verticalInput != 0)
            transform.Rotate(Vector3.up, Time.deltaTime * speedTurn *  hotrizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
        }
        if(transform.rotation.z != 0 )
        {
           
            transform.Rotate(0,0,0);
        }
    }
}
