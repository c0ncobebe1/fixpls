using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] protected float speed = 2.0f;
    [SerializeField] protected Vector3 direction = Vector3.up;

    private void Update()
    {
        transform.parent.Translate(this.direction * Time.deltaTime *  this.speed);
    }
}
