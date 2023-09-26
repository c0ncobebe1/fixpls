using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get => instance;
    }
    

    [SerializeField] private Vector3 mouseWorldPos;
    [SerializeField] protected float onFire;
    public float OnFire { get => onFire;  }
    public Vector3 MouseWorldPos { get => mouseWorldPos; }
    private void Awake()
    {
        if (InputManager.instance != null)
        {
            Debug.LogError("Only 1 InputManager allow to exist");
        }
        InputManager.instance = this;
    }
    private void Update()
    {
        GetFire();
    }
    void FixedUpdate()
    {
        GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected virtual void GetFire()
    {
        this.onFire = Input.GetAxis("Fire1");
    }

}
