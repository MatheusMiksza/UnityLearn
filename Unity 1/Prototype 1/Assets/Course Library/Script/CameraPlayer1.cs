using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer1 : MonoBehaviour
{
    public GameObject Player1;

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset ;
    public Vector3 rotationOffset;
    private Vector3 offset = new Vector3(0, 3.4f, -7);

    // Start is called before the first frame update
    void Start()
    {
        locationOffset = new Vector3(0, 4 ,- 8);
        rotationOffset = new Vector3(15, 0, 0);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
        //ransform.position = new Vector3(Player1.transform.position.x , Player1.transform.position.y + 3.4f, Player1.transform.position.z + -7);// Player1.transform.position + offset;
        

        //transform.rotation = Player1.transform.rotation;
    }
}
