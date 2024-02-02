using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Players players;
    [SerializeField] private GameObject playerArms;
    [SerializeField] private AudioClip audioClip; 

    [SerializeField] bool isPlayer1;
    public bool IsPlayer1() { return isPlayer1; }

    private AudioSource audioSource;

    private float moveSpeed = 10;
    public float playerDistLimit = 7;

    private bool isWalking = false;
    public bool IsWalking() { return isWalking; }

    private bool isPunching = false;
    public bool IsPunching() { return isPunching; }

    private void Start()
    {
        if (isPlayer1) gameInput.OnPlayer1Interaction += OnPlayerInteraction; 
        else gameInput.OnPlayer2Interaction += OnPlayerInteraction; 
        audioSource = GetComponent<AudioSource>();
    }

    private void OnPlayerInteraction(object sender, EventArgs e) 
    { 
        if (GameManager.Singleton.current_state != GameState.Playing) return;
        
        audioSource.PlayOneShot(audioClip);
        playerArms.SetActive(true);
        isPunching = true;
        StartCoroutine(ExecuteAfterTime(0.21f));
    }

    private IEnumerator ExecuteAfterTime(float time) 
    {
        yield return new WaitForSeconds(time);
        isPunching = false;
        playerArms.SetActive(false);
    }

    private void Update()
    {
        if (isPlayer1) HandlePlayerMovement(gameInput.GetPlayer1MoveDir());
        else HandlePlayerMovement(gameInput.GetPlayer2MoveDir());
    }

    private void HandlePlayerMovement(float moveDir) 
    {
        float playerDistance = players.GetPlayersDistance();

        if (transform.position.x <= -8.5 && moveDir < 0 || GameManager.Singleton.current_state != GameState.Playing)
        {
            isWalking = false;
            return;
        } else if (transform.position.x >= 8.5 && moveDir > 0)
        {
            isWalking = false;
            return;
        }

        if (Math.Abs(playerDistance) < playerDistLimit) 
        {
            if (moveDir != 0) isWalking = true;
            Move(moveDir); 
        } else  // players distance limit reached
        {
            // player 1 on the left, player 2 on the right
            if (playerDistance < 0)
            {
                // player 1 moving right or player 2 moving left
                if (isPlayer1 && moveDir > 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir); 
                }
                else if (!isPlayer1 && moveDir < 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir); 
                } else isWalking = false;
            } else // player 1 on the right, player 2 on the left
            {
                // player 1 moving left
                if (isPlayer1 && moveDir < 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir); 
                } else if (!isPlayer1 && moveDir > 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir);  
                } else isWalking = false;
            }
        }

        if (moveDir == 0) isWalking = false;
    }

    private void Move(float moveDir) 
    {
        transform.position += new Vector3(moveDir * Time.deltaTime * moveSpeed, 0); 
    }
}
