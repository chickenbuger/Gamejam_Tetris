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

    public void RequestCreateMino()
    {
        int RandomIndex = UnityEngine.Random.Range(0, 7);
        CreateMino(RandomIndex);
    }

    private void CreateMino(int _index)
    {   
        Instantiate(MinoObjects[_index], SpawnerPosition, Quaternion.identity);
    }
}
