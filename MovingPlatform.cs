using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public float movingX;
    public float movingY;
    private int lastY = 0;

    public void FixedUpdate()
    {
        if (lastY < movingX)//Эти условия нужны чтобы платформа до старта красиво то поднималась то опускалась
        {
            lastY += 1;
        }
        else if (lastY == movingX)
        {
            movingX = (-movingX);
            movingY = (-movingY);
        }
        else 
        {
            lastY -= 1;
        }
        float lastY2 = lastY / 1000f;// Это нужно для избежания мантиссы

        transform.Translate(new Vector3(movingX, movingY, 0) * Time.deltaTime);
    }
}