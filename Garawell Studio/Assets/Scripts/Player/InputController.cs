using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    bool isMouse;
    [SerializeField] float _rotateSpeed;
    private float horizontal;
    public Transform _player;
    [SerializeField] float Speed;

    //For Rope Renderer
    [Header("Rope")]
    [SerializeField] Transform _playerCenter;
    [SerializeField] Transform _ballCenter;
    [SerializeField] LineRenderer _ropeRenderer;
    void Update()
    {
        CheckGround();

        float rotate = 0;
        if (Input.GetMouseButton(0))
        {
            rotate += ClampRotate(Input.mousePosition.x - horizontal);          
        }
        horizontal = Input.mousePosition.x;
        if (Input.touchCount > 0)
        {
            rotate = ClampRotate(Input.GetTouch(0).deltaPosition.x);
            // doSkidTrail();
        }
        _player.Rotate(new Vector3(0, rotate, 0) * Time.deltaTime);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        drawRope();
    }

    private void CheckGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitinfo;
        Debug.DrawRay(transform.position, Vector3.down * 100, Color.red, 2f);
        if (Physics.Raycast(ray, out hitinfo, 10))
        {
        }
        else
        {
            _player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private float ClampRotate(float value)
    {
        return Mathf.Clamp(value * _rotateSpeed, -600, 600);
    }
  
    void drawRope()
    {
        _ropeRenderer.positionCount = 2;
        _ropeRenderer.SetPosition(0, _playerCenter.position);
        _ropeRenderer.SetPosition(1, _ballCenter.position);
    }
}
