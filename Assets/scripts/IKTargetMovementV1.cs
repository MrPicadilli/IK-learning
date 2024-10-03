using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetMovementV1 : MonoBehaviour
{

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            transform.position += Vector3.left * speed ;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * speed;
        if (Input.GetKey(KeyCode.Q))
            transform.position += Vector3.forward * speed;
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * speed;
        
        //Time.deltaTime;

    }
}
