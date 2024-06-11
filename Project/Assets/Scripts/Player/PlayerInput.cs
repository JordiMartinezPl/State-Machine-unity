using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float movementHorizontal { get; private set; }
    public float movementVertical { get; private set; }
    public bool sneak;

    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        movementVertical = Input.GetAxis("Vertical");
        sneak = Input.GetKey(KeyCode.LeftShift);
    }
}
