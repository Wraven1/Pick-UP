using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1.0f;
    public float sensitivityJoystick = 1;// Чувствительность мыши
    public float maxYAngle = 80.0f; // Максимальный угол вращения по вертикали
    public Joystick joystick;
    private float rotationX = 0.0f;
    private void FixedUpdate()
    {
        
        
        float mouseX = 0;
        float mouseY = 0;
        
        
        float joyX = joystick.Horizontal;
        float joyY = joystick.Vertical;

        if (Mathf.Abs(joyX) > 0.1f)
        {
          mouseX = joyX * sensitivityJoystick;
        }

        if (Mathf.Abs(joyY) > 0.1f)
        {
          mouseY = joyY * sensitivityJoystick;
        }
           
        
        
        
        // Вращаем персонажа в горизонтальной плоскости
        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);
        
        // Вращаем камеру в вертикальной плоскости
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
