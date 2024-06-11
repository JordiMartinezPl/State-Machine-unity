using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool checkIsMoving => isMoving;

    [SerializeField]
    private float speed = 5.0f;

    private bool isMoving;
    PlayerInput input;
    Rigidbody2D rigidBody;
    private float distanceTraveled = 0f;
    public Text distanceText;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        UpdateTimerAndDistance();

    }

    private void Move()
    {
        Vector2 direction = new Vector2(input.movementHorizontal, input.movementVertical)
            * (input.sneak ? speed / 2 : speed);
        rigidBody.velocity = direction;
        isMoving = direction.magnitude > 0.01f;

        if (isMoving) lookAt((Vector2)transform.position + direction);
        else transform.rotation = Quaternion.identity;
    }

    void lookAt(Vector2 targetPosition)
    {
        float angle = 0.0f;
        Vector3 relative = transform.InverseTransformPoint(targetPosition);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);
    }

    private void UpdateTimerAndDistance()
    {
        
        distanceTraveled += rigidBody.velocity.magnitude * Time.deltaTime;

      

        if (distanceText != null)
            distanceText.text = "Distance: " + Mathf.Round(distanceTraveled).ToString() + "m";
    }
    public float getdistanceTraveled() { return distanceTraveled; }
}
