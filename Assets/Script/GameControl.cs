using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livestxt;
    [SerializeField] TextMeshProUGUI scoretxt;
    PlayerMovement playerMovement;
    SceneController sceneController;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        sceneController = FindObjectOfType<SceneController>();
        int count = FindObjectsOfType<GameControl>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        livestxt.text = lives.ToString();
        scoretxt.text = score.ToString();
    }
    public void PlayerProcess()
    {
        if (!playerMovement.GetPlayerStatus()) return;
        if (lives > 1)
        {
            TakeLife();
        }
        else
        {
            //SceneManager.LoadScene(0);
            playerMovement.Die();
            Reset();
            FindObjectOfType<SceneMaintain>().SelfDes();
            sceneController.StopST();
        }
    }
    public void PlayerPoints()
    {
        score++;
        scoretxt.text = score.ToString();
    }
    private void Reset()
    {
        Destroy(gameObject);
    }

    private void TakeLife()
    {
        lives--;
        livestxt.text = lives.ToString();
    }
}
