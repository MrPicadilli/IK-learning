using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAniConScript : MonoBehaviour
{
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        Debug.Log("MyAniConScript: start => Animator");

    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        Debug.Log("HSpeed = " + Input.GetAxis("Vertical"));
        myAnimator.SetFloat("HSpeed", -Input.GetAxis("Horizontal"));
        Debug.Log("HSpeed = " + Input.GetAxis("Horizontal"));
    }
}
