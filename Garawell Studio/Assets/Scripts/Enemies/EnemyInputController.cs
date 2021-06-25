using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputController : MonoBehaviour
{ 

    //For Rope Renderer
    [Header("Rope")]
    [SerializeField] Transform _playerCenter;
    [SerializeField] Transform _ballCenter;
    [SerializeField] LineRenderer _ropeRenderer;
    void Update()
    {
        drawRope();
    }
    void drawRope()
    {
        _ropeRenderer.positionCount = 2;
        _ropeRenderer.SetPosition(0, _playerCenter.position);
        _ropeRenderer.SetPosition(1, _ballCenter.position);
    }
}
