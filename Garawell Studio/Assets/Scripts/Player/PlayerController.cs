using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] float _forwardSpeed;
    [SerializeField] float _turnSpeed;
    [SerializeField] CharacterController controller;
    Vector3 rotation;
    [Header("Bools")]
    bool moveLeft;
    bool moveRight;

    void Update()
    {
        // ForwardMove();
        // Turn();
        Move();
    }

    private void Move()
    {
        rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _turnSpeed * Time.deltaTime, 0);
        Vector3 move = new Vector3(0, 0, _forwardSpeed * Time.deltaTime);
        move = transform.TransformDirection(move);
        controller.Move(move * _forwardSpeed);
        transform.Rotate(rotation);
    }

    // private void Turn()
    // {
    //     Quaternion rotation = Quaternion.Euler(new Vector3(0, -Input.GetAxis("Horizontal"), 0) * -_turnSpeed * Time.deltaTime);
    //     transform.rotation = rotation;
    // }
    //
    // private void ForwardMove()
    // {
    //     Vector3 moveVector = Vector3.forward;
    //     controller.Move(moveVector * _forwardSpeed * Time.deltaTime);
    // }

    //For TouchController
    public void MoveLeftTrue()
    {
        moveLeft = true;
    }
    public void MoveLeftFalse()
    {
        moveLeft = false;
    }

    public void MoveRightTrue()
    {
        moveRight = true;
    }
    public void MoveRightFalse()
    {
        moveRight = false;
    }
}
