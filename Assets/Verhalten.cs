using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verhalten : MonoBehaviour
{
    [SerializeField]
    private Transform prefab;

    [SerializeField] private float rotateSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
// Update is called once per frame
    void Update()
    {
        var position = prefab.position;
        prefab.transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Aayayaaayayayay");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.LogWarning("Nonononono");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning("NICE");
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        Debug.LogWarning("Hello there");
    }
}
