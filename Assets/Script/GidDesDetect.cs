using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GidDesDetect : MonoBehaviour
{
    [SerializeField] float TimeDestroyDelay = 2f;
    BackGroundController backGroundController;
    Enemy enemy;
    private void Start()
    {
        backGroundController = FindObjectOfType<BackGroundController>();
        enemy = FindObjectOfType<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke("Destroy", TimeDestroyDelay);
            backGroundController.ChangeBackGround();
            enemy.speedUp();
        }
    }
    private void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
