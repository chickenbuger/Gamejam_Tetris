using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 SpawnerPosition;
    public GameObject[] MinoObjects;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public GameObject RequestCreateMino()
    {
        int RandomIndex = UnityEngine.Random.Range(0, 7);
        return CreateMino(RandomIndex);
    }

    private GameObject CreateMino(int _index)
    {   
        GameObject SpawnActor = Instantiate(MinoObjects[_index], SpawnerPosition, Quaternion.identity);
        SpawnActor.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        return SpawnActor;
    }
}
