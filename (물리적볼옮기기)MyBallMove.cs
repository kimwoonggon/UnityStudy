using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBallMove : MonoBehaviour
{
    Rigidbody rigid;
    //
    // Start is called before the first frame update
    void Start()
    {
        //rigid = 
        //rigid.velocity = new Vector3(2,10,3);
        //if (Input.GetButtonDown("Jump"))
        //    rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);        
    }

    // Update is called once per frame
    void Update()
    {
        //rigid.velocity = new Vector3(2, 10, -1);
    }

    private void FixedUpdate()
    {
        //1. 충격량 주어 공 움직이기.
        rigid = GetComponent<Rigidbody>();
        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"),
            0, Input.GetAxisRaw("Vertical"));

        rigid.AddForce(vec, ForceMode.Impulse);
        //2. 회전력
        ///rigid = GetComponent<Rigidbody>();
        //rigid.AddTorque(Vector3.up);
    }
}
