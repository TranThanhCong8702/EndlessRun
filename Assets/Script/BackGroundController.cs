using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] List<Sprite> list = new List<Sprite>();
    [SerializeField] Image imagel;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    PlayerMovement playerMovement;
    float temp;
    float tmp;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Start()
    {
        temp = playerMovement.GetCountDown();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (!playerMovement.GetPlayerStatus()) return;
        tmp -= Time.deltaTime;
        int numb = (int)(tmp + temp);
        textMeshProUGUI.text = numb.ToString();
        if (numb < 0)
        {
            textMeshProUGUI.gameObject.SetActive(false);
        }
    }
    public void ChangeBackGround()
    {
        int i = Random.Range(0, list.Count);
        imagel.sprite = list[i];
        Debug.Log("Hello");
    }
}
