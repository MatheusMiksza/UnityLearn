using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Course_Library.Script.NPC_Util;

public class NPCCar : MonoBehaviour
{
    public float speed = 0;
    public Vector3 startPosition;

    public float offX;
    public float offY;
    public float offZ;
    public float rotationY;
    public float positionXMax;
    public float positionXMin;
    public float speedRotate;
    public float tmpY;


    private Vector3 offset;
    private NPCBussines npcBussines;
    // Start is called before the first frame update
    void Start()
    {
        npcBussines = new NPCBussines(speed);
        startPosition = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(npcBussines.NPCMoviment());
        if (transform.position.x >= positionXMin &&//- 5 &&
            transform.position.x < positionXMax &&// 2 &&
            transform.rotation.y <= rotationY)//-0.456546)
        {

            transform.Rotate(0, transform.rotation.y * speedRotate, 0);
            transform.Translate(npcBussines.NPCMoviment());
        }
        else
        {
            transform.Translate(npcBussines.NPCMoviment());
        }

        //if (transform.position.x <= -100 && 
        //    transform.rotation.y > -0.890000)
        //{
        //    transform.Rotate(0, transform.rotation.y * - 1.4f, 0);
        //    transform.Translate(npcBussines.NPCMoviment());
        //}
    }
}
