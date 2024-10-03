using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerosControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }


/*Tourner seulement si la touche “contrôle” est enfoncée
Accélérer/freiner/tourner avec les touches du claviers
Ajoutez une rotation verticale pour pouvoir regarder en haut
Activez les collisions entre votre capsule/perso et des cubes posés dans la scène
Ajoutez des possibilités de tir de sphères droit devant*/

    // Update is called once per frame
    void Update()
    {
        Vector3 forward_world = transform.TransformDirection(Vector3.forward);
        transform.position += forward_world * Time.deltaTime * speed;
        
        //gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(input * speed * Time.deltaTime));
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);
        
        if (Input.GetKey(KeyCode.Z))
        {
            if(speed <= 5.5){
                speed*=1.1f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed*=0.9f;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed);
        }

    }
}









