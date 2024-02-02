using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPlayer1Interaction;
    public event EventHandler OnPlayer2Interaction;

    private PlayerInputActions inputActions;

    private float player1MoveDir;
    public float GetPlayer1MoveDir() { return player1MoveDir; }
    private float player2MoveDir;
    public float GetPlayer2MoveDir() { return player2MoveDir; }

    private bool player1Interacted = false;
    private bool bothPlayersInteracted = false;
    public bool BothPlayersInteracted() { return bothPlayersInteracted; }

    private void Awake() 
    {
        inputActions = new PlayerInputActions();

        inputActions.Player1.Enable();
        inputActions.Player2.Enable();

        inputActions.Player1.Interact.performed += Player1Interact_performed;
        inputActions.Player2.Interact.performed += Player2Interact_performed;
        inputActions.Player1.Interact.canceled += ctx => player1Interacted = false;
        inputActions.Player2.Interact.canceled += ctx => bothPlayersInteracted = false;
    }

    private void Player1Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) 
    { 
        player1Interacted = true;
        OnPlayer1Interaction?.Invoke(this, EventArgs.Empty); 
    }

    private void Player2Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) 
    { 
        if (player1Interacted) bothPlayersInteracted = true;
        OnPlayer2Interaction?.Invoke(this, EventArgs.Empty); 
    }

    private void Update()
    {
        player1MoveDir = inputActions.Player1.Move.ReadValue<float>();
        player2MoveDir = inputActions.Player2.Move.ReadValue<float>();
    }
}
