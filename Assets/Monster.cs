using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private int generateMonster = 10;

    [SerializeField] private Transform parent;
    
    [SerializeField] private float rangeX = 30f;
    [SerializeField] private float rangeZ = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < generateMonster; i++)
        {
            var rotation = Random.Range(0, 180);
            var positionRangeX = Random.Range(-rangeX, rangeX);
            var positionRangeZ = Random.Range(-rangeZ, rangeZ);
            var createdObj = Instantiate(prefab, new Vector3(positionRangeX,0, positionRangeZ), Quaternion.Euler(0, rotation, 0));
            createdObj.SetParent(parent);
        }
    }

}