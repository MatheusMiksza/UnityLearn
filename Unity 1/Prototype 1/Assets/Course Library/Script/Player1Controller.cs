using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private float horseSpeed = 0;
    [SerializeField] private float rpm = 0;
    private float speed = 15;
    private float speedTurn = 25;
    private float rotationSpeed;
    private float verticalInput;
    private float hotrizontalInput;
    private float offX;
    private float offY;
    private float offZ;

    private Vector3 offset;

    public Camera mainCamera;
    public Camera hoodCamera;

    public KeyCode switchKey;

    private Rigidbody plRigidbody;

    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI velocimetroText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;

    // Start is called before the first frame update
    void Start()
    {
        plRigidbody = GetComponent<Rigidbody>();
        plRigidbody.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        SetPainel();
        hotrizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput < 0) hotrizontalInput = hotrizontalInput * -1;

        //if (transform.rotation.z >= 90 || transform.rotation.z <= -90 )
        //    transform.Rotate(0,0,0);

        //offZ = Time.deltaTime * speed * verticalInput;

        //offY = 0;
        //offX = 0;
        //offset = new Vector3(offX, offY, offZ);
        // get the user's vertical input


        // move the plane forward at a constant rate
        //transform.Translate(offset);

        if(speed <= 100 && isGround())
            plRigidbody.AddRelativeForce(Vector3.forward * verticalInput * horseSpeed);

        // tilt the plane up/down based on up/down arrow keys
        if(speed != 0)
            transform.Rotate(Vector3.up, Time.deltaTime * speedTurn *  hotrizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
        }
        //if(transform.rotation.z != 0 )
        //{

        //    transform.Rotate(0,0,0);
        //}
        UpdatePainel();
    }

    void UpdatePainel()
    {
        velocimetroText.SetText($"Speed: {speed} Km/h");
        rpmText.SetText($"RPM: {rpm}");
    }
    void SetPainel()
    {
        speed = Mathf.RoundToInt(plRigidbody.velocity.magnitude * 3.6F);
        rpm = (speed % 30) * 40;
    }

    bool isGround()
    {
        int isOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded) isOnGround++;
        }

        return isOnGround == 4 ? true : false;
    }
}
