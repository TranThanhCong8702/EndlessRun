using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject Ending;
    PlayerMovement playerMovement;
    AudioSource audioSource;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayST()
    {
        audioSource.Play();
        playerMovement.Starting();
        GameObject.FindGameObjectWithTag("Start").gameObject.SetActive(false);
    }
    public void StopST()
    {
        Ending.SetActive(true);
    }
    public void EndST()
    {
        audioSource.Play();
        Invoke("Restart", 1f);
    }
    void Restart()
    {
        GameObject.FindGameObjectWithTag("Ending").gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
