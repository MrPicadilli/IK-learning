using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetMovement : MonoBehaviour
{

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad4))
            transform.position += Vector3.left * speed ;
        if (Input.GetKey(KeyCode.Keypad6))
            transform.position += Vector3.right * speed;
        if (Input.GetKey(KeyCode.Keypad8))
            transform.position += Vector3.forward * speed;
        if (Input.GetKey(KeyCode.Keypad2))
            transform.position += Vector3.back * speed;
        
        //Time.deltaTime;

    }
    private void Awake() {
        //se fait avant le start
        
    }
    private void LateUpdate() {
        //appel apres update
    }
    private void FixedUpdate() {
        // frequence differente de update
    }
}
