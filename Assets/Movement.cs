using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Transform player;

    [SerializeField] private float speed = 20.0f;

    private float angle = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.rotation = RotationCalu(false);
            //player.Rotate(0, -(angle + 1), 0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            player.rotation = RotationCalu(true);
            //player.Rotate(0, (angle + 1), 0);
        }
        else
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            var direction = new Vector3(moveHorizontal, 0, moveVertical);
            player.Translate(direction * (Time.deltaTime * speed));
        }
    }

    private Quaternion RotationCalu(bool posNeg)
    {
        if (posNeg)
            angle += 100 * Time.deltaTime;
        else
            angle -= 100 * Time.deltaTime;

        var targetDirection = new Vector3(Mathf.Sin(angle),
            0,
            Mathf.Cos(angle));
        var looking = Quaternion.LookRotation(targetDirection);
        return looking;
    }
}