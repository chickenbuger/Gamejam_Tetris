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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateObjectSpawner()
    {
        Instantiate(ObjectSpawner, transform.position, Quaternion.identity);
    }
}
