using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public GameObject ObjectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        CreateObjectSpawner();

        InvokeRepeating("RequestSpawnerMinoActorToSpawner", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RequestSpawnerMinoActorToSpawner()
    {
        ObjectSpawner.GetComponent<Spawner>().RequestCreateMino();
    }

    private void CreateObjectSpawner()
    {
        Instantiate(ObjectSpawner, transform.position, Quaternion.identity);
    }
}
