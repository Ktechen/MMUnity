using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualBtnHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;

    private float _angle = 0;
    private float Speed { get; set; } = 20.0f;
    private const int DefaultSpeed = 5;

    private bool isRotateLeft = false;
    private bool isRotateRight = false;
    private bool isForward = false;
    private bool isBackward = false;

    void Start()
    {
        var vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        foreach (var btn in vbs)
        {
            btn.RegisterOnButtonPressed(OnButtonPressed);
            btn.RegisterOnButtonReleased(OnButtonReleased);
        }
    }
    private void OnButtonReleased(VirtualButtonBehaviour obj)
    {
        switch (obj.VirtualButtonName)
        {
            case "RotateLeft":
                isRotateLeft = false;
                break;
            case "RotateRight":
                isRotateRight = false;
                break;
            case "Forward":
                isForward = false;
                break;
            case "Backward":
                isBackward = false;
                break;
        }
    }

    private void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "RotateLeft":
                isRotateLeft = true;
                break;
            case "RotateRight":
                isRotateRight = true;
                break;
            case "Forward":
                isForward = true;
                break;
            case "Backward":
                isBackward = true;
                break;
        }
    }

    private void Update()
    {
        if (isForward)
        {
            MovePlayer(DefaultSpeed);
        }

        if (isBackward)
        {
            MovePlayer(-DefaultSpeed);
        }

        if (isRotateLeft)
        {
            player.rotation = RotationCalu(false);
        }

        if (isRotateRight)
        {
            player.rotation = RotationCalu(true);
        }
    }

    private void MovePlayer(float z)
    {
        var direction = new Vector3(0, 0, z);
        player.Translate(direction * (Time.deltaTime * Speed));
    }

    private Quaternion RotationCalu(bool posNeg)
    {
        if (posNeg)
            _angle += 1000 * Time.deltaTime;
        else
            _angle -= 1000 * Time.deltaTime;

        var targetDirection = new Vector3(Mathf.Sin(_angle),
            0,
            Mathf.Cos(_angle));
        var looking = Quaternion.LookRotation(targetDirection);
        return looking;
    }
}
