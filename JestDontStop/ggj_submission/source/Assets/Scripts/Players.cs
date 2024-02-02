using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;  
    
    public float playerDistance;
    public float GetPlayersDistance() { return playerDistance; }

    public float GetPlayersMidPointX() { return (player1.transform.position.x  + player2.transform.position.x) / 2f; }

    private void Start()
    {
        gameInput.OnPlayer2Interaction += BothPlayersInteraction;
    }

    private void Update() 
    {
        playerDistance = player1.transform.position.x - player2.transform.position.x;
    }

    private void BothPlayersInteraction(object sender, System.EventArgs e) 
    {
        if (!gameInput.BothPlayersInteracted()) return;
        Debug.Log("Both Players Punched");
    }
}
