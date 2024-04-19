using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxXPos;
    [SerializeField] private Transform geoTrans;

    private Camera cam;

    private float xOffset;
    private Vector3 origPos;
    private Vector3 oldPos;
    
    private void Awake()
    {
        cam = Camera.main;
        origPos = transform.position;
        oldPos = origPos;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            xOffset = transform.position.x - GetWorldPos().x;
        }
        
        if (Input.GetMouseButton(0))
        {
            var newPos = GetWorldPos();
            newPos.x += xOffset;
            newPos.x = Mathf.Clamp(newPos.x, minMaxXPos.x, minMaxXPos.y);

            transform.position = new Vector3(newPos.x, origPos.y, origPos.z);

            var dir = oldPos.x - transform.position.x;
            geoTrans.localScale = dir > 0.1f ? new Vector3(-1.0f, 1, 1) : Vector3.one;
        }
    }

    private void LateUpdate()
    {
        oldPos = transform.position;
    }

    private Vector3 GetWorldPos()
    {
        return cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Mathf.Abs(transform.position.z - cam.transform.position.z)));
    }
}
