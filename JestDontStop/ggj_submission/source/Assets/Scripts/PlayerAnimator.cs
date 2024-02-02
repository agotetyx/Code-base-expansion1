using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameInput gameInput;

    private const string IS_WALKING = "IsWalking";
    private const string PUSH = "Push";

    private Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
        if (player.IsPlayer1()) 
        {
            gameInput.OnPlayer1Interaction += PushAnimate;
        }
        else gameInput.OnPlayer2Interaction += PushAnimate;
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }

    private void PushAnimate(object sender, System.EventArgs e)
    {
        animator.SetTrigger(PUSH);
    }
}
