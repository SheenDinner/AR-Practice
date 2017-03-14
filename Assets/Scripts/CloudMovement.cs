using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

    Rigidbody rb;

    void Start () {
	    rb =this.GetComponent<Rigidbody>(); ;
        rb.AddForce(Vector3.forward * 60f);
    }
	
    void FixedUpdate()
    {
        
    }

	void Update () {
     
    }
}
