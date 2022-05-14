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
        Debug.Log(obj.name);
    }

    private void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "RotateLeft":
                player.rotation = RotationCalu(false);
                break;
            case "RotateRight":
                player.rotation = RotationCalu(true);
                break;
            case "Forward":
                MovePlayer(DefaultSpeed);
                break;
            case "Backward":
                MovePlayer(-DefaultSpeed);
                break;
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