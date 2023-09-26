using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 TargetPos;
    [SerializeField] protected float speed = 0.1f;
    void FixedUpdate()
    {
        this.GetTargetPos();

        this.Moving();
        
    }
    protected virtual void GetTargetPos()
    {
        this.TargetPos = InputManager.Instance.MouseWorldPos;
        this.TargetPos.z = 0;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, TargetPos, speed);
        transform.parent.position = newPos;
    }
    
}
