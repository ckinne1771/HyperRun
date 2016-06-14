using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    float movementSpeed = 1.0f;
    float rotationSpeed = 100.0f;
    float translation;
    float maxSpeed = 7.0f;
    Vector3 velocity = Vector3.zero;

      // Use this for initialization
      void Start () {

      }

      // Update is called once per frame
      void Update () {
        translation = this.transform.forward.z * movementSpeed;
       if(Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            if (movementSpeed < 20.0f)
            {
                movementSpeed += 0.1f;
            }
            translation = Input.GetAxis("Vertical") * movementSpeed;
        }
       

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (movementSpeed > 0)
            {
                movementSpeed -= 0.5f;
            }
        }
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        this.transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

}
  


