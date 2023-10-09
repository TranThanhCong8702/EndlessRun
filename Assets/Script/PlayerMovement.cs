using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector2 MoveInput;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float CountDownToStart = 2f;
    Rigidbody2D playerRb;
    bool isAlive = false;
    Animator animator;
    ParticleSystemOlay particle;
    CapsuleCollider2D capsuleCollider;
    AudioSource audioPlayer;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        particle = FindObjectOfType<ParticleSystemOlay>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        SetAlive();
    }
    public void Die()
    {
        audioPlayer.Play();
        isAlive = false;
    }
    public void Starting()
    {
        isAlive = true;
    }
    public bool GetPlayerStatus()
    {
        return isAlive;
    }
    private void SetAlive()
    {
        if (playerRb.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            particle.ParticlePlay();
            FindObjectOfType<GameControl>().PlayerProcess();
        }
    }

    void Run()
    {
        Invoke("Running", CountDownToStart);
    }
    void Running()
    {
        Vector2 move = new Vector2(moveSpeed, playerRb.velocity.y);
        playerRb.velocity = move;
        bool isRunning;
        if (isAlive)
        {
            isRunning = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
        }
        else
        {
            isRunning = false;
            animator.SetBool("IsAlive", isAlive);
        }
        animator.SetBool("IsRunning", isRunning);
    }
    void OnJump(InputValue value)
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))) return;
        if (!isAlive) { return; }
        if (value.isPressed)
        {
            playerRb.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    public float GetCountDown()
    {
        return CountDownToStart;
    }
}
