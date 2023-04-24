using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Course_Library.Script.NPC_Util;

public class NPCBuss : MonoBehaviour
{
    public float speed = 0;
    public Vector3 startPosition;

    public float offX;
    public float offY;
    public float offZ;
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
        if(transform.position.z < 0)
        {
            transform.Translate(startPosition.x - transform.position.x, startPosition.y,174 * -1);
        }
        else
        {
            transform.Translate(npcBussines.NPCMoviment());
        }

    }
}
