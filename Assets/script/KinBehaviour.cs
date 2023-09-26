using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinBehaviour : MonoBehaviour
{
    protected void Reset()
    {
        this.LoadComponent();
    }
    protected virtual void Start()
    {
        //
    }

    protected virtual void LoadComponent()
    {
        // for override
    }

    protected virtual void Awake()
    {
        this.LoadComponent();
    }
}
