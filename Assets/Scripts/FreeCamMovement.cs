using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FreeCamMovement : MonoBehaviour
{
    [SerializeField]private CamPivot ParentPos;

    void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit result))
        {
            ParentPos.UpdatePos(result.transform.position);
            transform.parent = ParentPos.transform;
        }
    }
    
    public void Zoom(Vector2 _v)
    {
        transform.Translate(Vector3.forward * (_v.y - _v.x));
    }

    void Update()
    {
        Vector3 point = Vector3.zero;
    }

}
