using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag =="Floor")
        {
            CCMovementScript.isGrounded = true;
        }
        if(other.gameObject.tag == "RunnableWall")
        {
            CCMovementScript.isGrounded = true;
        }
    }
 
}
