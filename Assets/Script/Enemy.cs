using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float EnemySpeed;
    [SerializeField] float SpeedUp;
    PlayerMovement playerMovement;
    Rigidbody2D rigidbody2;
    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    public void speedUp()
    {
        if (EnemySpeed >= 3.8) return;
        EnemySpeed += SpeedUp;
    }
    void EnemyMoving()
    {
        rigidbody2.velocity = new Vector2(EnemySpeed, 0);
    }
    private void Update()
    {
        if (!playerMovement.GetPlayerStatus()) return;
        EnemyMoving();
    }
}
