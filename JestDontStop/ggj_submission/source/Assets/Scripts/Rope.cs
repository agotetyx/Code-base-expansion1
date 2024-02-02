using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] public Players players;
    [SerializeField] public GameObject ropeVisual;

    public float ropeMinWidth =  0.3f;
    public float ropeMaxWidth =  0.05f;
    public float playerDistLimit = 7;
    public float yOffset = -0.3f;
    public float zOffset = 0.01f;

    public void Update() 
    {
        transform.localScale = new Vector3(Math.Abs(players.GetPlayersDistance()), map(Math.Abs(players.GetPlayersDistance()), 0, playerDistLimit, ropeMinWidth, ropeMaxWidth), 1);
        transform.localPosition = new Vector3(players.GetPlayersMidPointX(), yOffset, zOffset);
        if (Math.Abs(players.GetPlayersDistance()) >= playerDistLimit) ropeVisual.GetComponent<SpriteRenderer>().color = new Color(1, 0,0, 1);
        else ropeVisual.GetComponent<SpriteRenderer>().color = new Color(160/255f, 82/255f, 45/255f, 1f);
    }

    public float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
