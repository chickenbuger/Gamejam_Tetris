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
        MinoObjects = new GameObject[7];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnActor(int Index)
    {

    }
}
