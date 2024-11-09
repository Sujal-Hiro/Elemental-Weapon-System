using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    private Vector2 touchStartPos;
    public float rotationSpeed = 5f;

    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Debug.Log("Mobile Input");
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }

           
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.position - touchStartPos;

               
                float angle = touchDelta.x * rotationSpeed * Time.deltaTime;

              
                transform.Rotate(0, angle, 0, Space.World);

               
                touchStartPos = touch.position;
            }
        }

        else if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            //Debug.Log("PC Input");

            if (Input.GetMouseButtonDown(0))
            {
                touchStartPos = mousePos;
            }

            Vector2 mouseDelta = mousePos - touchStartPos;
            float angle = mouseDelta.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(0, angle, 0, Space.World);
            touchStartPos = mousePos;
        }
    }
}
