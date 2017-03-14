using UnityEngine;
using System.Collections;

public class God : MonoBehaviour
{

    public Camera camera;
    public GameObject lightningBoltPrefab;

    bool moving = false;
    private Vector3 startPoint;
    private Vector3 endPoint;
    int layerMask = 1 << 8;
    Ray ray2;


    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, Time.deltaTime * 20f);

            if (this.transform.position == endPoint)
            {
                moving = false;
                shoot();
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            ray2 = ray;

            if (!moving && Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                moving = true;

                startPoint = this.transform.position;
                endPoint = new Vector3(hit.point.x, 10f, hit.point.z);
               // Debug.Log("Start: " + startPoint + "End: " + endPoint);
            }
        }
        Debug.DrawRay(ray2.origin, ray2.direction * 60, Color.red);
    }

    void shoot()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        GameObject go = Instantiate(lightningBoltPrefab, pos, transform.rotation) as GameObject;
        Destroy(go, 1.0f);
    }


}

