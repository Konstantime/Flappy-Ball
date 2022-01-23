using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public GameObject player;
    public float sizeMap;
    public double percentageTraveledDistance;

    void Update()
    {
        if ((player.transform.position.x / sizeMap) * 100 > percentageTraveledDistance)
        {
            percentageTraveledDistance = Math.Round((player.transform.position.x / sizeMap) * 100, 0, MidpointRounding.AwayFromZero);
            scoreText.text = (percentageTraveledDistance.ToString("N0") + "%");
        }
    }
}
