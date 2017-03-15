using UnityEngine;
using System.Collections;

public class Chicken : MonoBehaviour {

    MeshRenderer mr;
    Animator anim;
    Rigidbody rb;
    private Vector3 target;
    UnityEngine.AI.NavMeshAgent agent;

 

    void Start () {
        mr = GetComponent<MeshRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        float startDelay = Random.Range(0, 2f);     
        InvokeRepeating("randMove", startDelay, 2.0f);
    }
	
	void Update () {
 
    }

    void randMove()
    {
        float x = Random.Range(-2f, 7f);
        float y = 0f;
        float z = Random.Range(-15f, 16f);
        target = new Vector3(x, y, z);
        agent.SetDestination(target);

    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.blue);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collision with particle");
        Destroy(this);
    }


}
