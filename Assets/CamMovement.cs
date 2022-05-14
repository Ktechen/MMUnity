using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new(1.0f, -5.0f, 20.0f);
    [SerializeField] private float smoothFactor = 2.0f;
    [SerializeField] private float speed = 3.0f;

    private Vector3 cameraOffset;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        
    }
    void Update()
    {
        /*
        var newPosition = target.transform.position + cameraOffset;
        var position = target.position;
        transform.position = position + offset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        */
        var offsetRotation = target.rotation * offset;
        //var targetRotation = Quaternion.LookRotation(offsetRotation);
        var transform1 = transform;
        transform1.position = target.position - offsetRotation;
        transform.rotation = target.rotation;
        //Quaternion.Slerp(transform1.rotation, targetRotation, speed * Time.deltaTime);
    }
}