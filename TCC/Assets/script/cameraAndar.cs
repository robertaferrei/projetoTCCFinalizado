using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAndar : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void Update()
    {
     /*   Vector3 desiredposition = target.position + offset;
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed);
        transform.position = smoothedposition;


        */
    }
}
