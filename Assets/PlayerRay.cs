using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer lineRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward*100f, Color.yellow);
        Vector3 endPosition = transform.position + (transform.forward * 100f);
        RaycastHit hit;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.gameObject);
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, endPosition);
        }
    }
}
