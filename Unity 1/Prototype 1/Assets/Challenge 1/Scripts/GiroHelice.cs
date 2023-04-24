using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroHelice : MonoBehaviour
{
    PlayerControllerX playerController = new PlayerControllerX();
    public float speedRotate = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float hotrizontalInput = Input.GetAxis("Horizontal");
        //if (speedRotate < 1000)
        //    speedRotate = speedRotate + hotrizontalInput;
        transform.Rotate(0, 0, Time.deltaTime * speedRotate);
    }
}
