using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaintain : MonoBehaviour
{
    private void Awake()
    {
        int count = FindObjectsOfType<SceneMaintain>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SelfDes()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
