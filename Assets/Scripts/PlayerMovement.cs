using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private Vector2 touchStartPos;
    public float rotationSpeed = 5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                
                Vector2 touchDelta = touch.position - touchStartPos;
                float angle = touchDelta.x * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, angle, 0, Space.World);
                touchStartPos = touch.position;

                
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }

        
        else if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                touchStartPos = mousePos;
            }

            Vector2 mouseDelta = mousePos - touchStartPos;
            float angle = mouseDelta.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, angle, 0, Space.World);
            touchStartPos = mousePos;

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
