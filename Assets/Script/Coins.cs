using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] AudioClip audioClip;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!playerMovement.GetPlayerStatus()) return;
        if (collision.transform.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
            FindObjectOfType<GameControl>().PlayerPoints();
            transform.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
