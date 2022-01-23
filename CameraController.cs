using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 posEnd, posSmooth;
    public float Smoothness;
    [SerializeField] private float endPositionX;

    public void FixedUpdate()
    {
        if ((player.transform.position.x + 6.5f) < endPositionX)
        {
            posEnd = new Vector3(player.transform.position.x + 6.5f, player.transform.position.y + 0.3f, transform.position.z);
        }
        else
        {
            posEnd = new Vector3(endPositionX, player.transform.position.y + 0.3f, transform.position.z);
        }
        posSmooth = Vector3.Lerp(transform.position, posEnd, Smoothness);
        transform.position = posSmooth;
    }
}