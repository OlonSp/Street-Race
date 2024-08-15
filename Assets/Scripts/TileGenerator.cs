using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>(); 
    private float SpawnPos = 0;
    private float tileLength = 50;

    [SerializeField] private Transform player;
    private int startTiles = 5;
    private int lastTile = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < startTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            int nowspawn = Random.Range(0, tilePrefabs.Length);
            while(nowspawn == lastTile)
                nowspawn = Random.Range(0, tilePrefabs.Length);
            lastTile = nowspawn;
            SpawnTile(nowspawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 20 > SpawnPos - tileLength * startTiles)
        {
            int nowspawn = Random.Range(0, tilePrefabs.Length);
            while (nowspawn == lastTile)
                nowspawn = Random.Range(0, tilePrefabs.Length);
            lastTile = nowspawn;
            SpawnTile(nowspawn);
            DeleteTiles();
        }
            
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject obj = Instantiate(tilePrefabs[tileIndex], transform.forward * SpawnPos, transform.rotation);
        activeTiles.Add(obj);
        SpawnPos += tileLength;
    }

    private void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
