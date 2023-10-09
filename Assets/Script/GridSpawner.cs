using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] float spawnDis = 100f;
    [SerializeField] List<GameObject> tilemaps = new List<GameObject>();
    [SerializeField] GameObject Grid;
    [SerializeField] Transform Player;
    Vector3 LastEndPos;
    private void Start()
    {
        LastEndPos = Grid.transform.Find("GridGenFlag").position;
    }
    private void Update()
    {
        if (Vector3.Distance(Player.position, LastEndPos) < spawnDis)
        {
            Gridspawner();
        }

    }

    private void Gridspawner()
    {
        GameObject nextLev;
        nextLev = Spawner(LastEndPos);
        LastEndPos = nextLev.transform.Find("GridGenFlag").position;
    }
    private GameObject Spawner(Vector3 pos)
    {
        Debug.Log("hello");
        int i = Random.Range(0, tilemaps.Count);
            GameObject nextLev = Instantiate(tilemaps[i], pos, Quaternion.identity);
            return nextLev;
    }
}
