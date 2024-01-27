using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public GameObject ObjectSpawner;

    /**
     * X -> xÃà Y -> yÃà
     * Z -> 0 ºó Ä­ 1 »ç¿ë Ä­ 2 Ãæµ¹ 3 º®
     */
    private Vector3[,] GridBoard;

    // Start is called before the first frame update
    void Start()
    {
        CreateObjectSpawner();

        GridBoard = new Vector3[21, 12];
        InitGridBoard();

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

    private void InitGridBoard()
    {
        for(int y=0;y<21;y++)
        {
            for(int x=0;x<12;x++)
            {
                GridBoard[y, x] = new Vector3(-7.0f + x * 0.5f, -5.5f + y * 0.5f, 0.0f);
                //Init Wall Setting
                if (x == 0 || x == 11) GridBoard[y, x].z = 3.0f;
                if (y == 0) GridBoard[y, x].z = 3.0f;
            }
        }
    }
}
