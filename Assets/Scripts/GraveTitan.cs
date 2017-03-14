using UnityEngine;
using System.Collections;

public class GraveTitan : MonoBehaviour {

    public GameObject bulletPrefab;
    
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            go.GetComponent<Rigidbody>().AddForce(transform.forward * 15, ForceMode.Impulse);
        }

	}
}
