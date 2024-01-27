using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class GameMode : MonoBehaviour
{
    public GameObject ObjectSpawner;
    public GridInde gridInde;              //그리드 인덱스값을 가지는 부모 스크립트

    /**
     * X -> x축 Y -> y축
     * Z -> 0 빈 칸 1 사용 칸 2 충돌 3 벽
     */
    private Vector3[,] GridBoard;

    // Start is called before the first frame update
    void Start()
    {
        CreateObjectSpawner();

        GridBoard = new Vector3[23, 14];
        InitGridBoard();

        InvokeRepeating("RequestSpawnerMinoActorToSpawner", 0.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestDisconnectController(GameObject _gameobject)
    {
        DisConnectController(gameObject);
    }

    public bool RequestGridIndexXY(Vector2[] _Vector2, GameObject parent)
    {
        for (int i = 0; i < _Vector2.Length; i++)
        {
            float temp = GridBoard[(int)_Vector2[i].y - 1, (int)_Vector2[i].x].z += 1;
            if (temp > 1)
            {
                GridBoard[(int)_Vector2[i].y - 1, (int)_Vector2[i].x].z -= 1;   //출동
                DisConnectController(gameObject);
                gameObject.GetComponent<Rigidbody>().useGravity= true;
            }
            else
            {
                GridBoard[(int)_Vector2[i].y, (int)_Vector2[i].x].z -= 1;   //이동
            }    
        }

        return true;
    }

    public void RequestDeleteGridBoardLineCheck(Vector3[] Positions)
    {
        float[] yDatas = new float[4];
        for(int i = 0; i < 4; i++)
        {
            yDatas[i] = Positions[i].y;
        }
        float[] uniqueArray = RemoveDuplicates(yDatas);
        int[] iy = CastPositionToGridIndex(uniqueArray);
        Array.Sort(iy,(a,b)=>b.CompareTo(a));
        bool[] bDatas = DeleteCheckGridLines(iy);
        DeleteGridLine(iy, bDatas);

        RequestSpawnerMinoActorToSpawner();
    }

    private void RequestSpawnerMinoActorToSpawner()
    {
        GameObject ParentObject = ObjectSpawner.GetComponent<Spawner>().RequestCreateMino();
        ConnectController(ParentObject);
    }

    private void CreateObjectSpawner()
    {
        Instantiate(ObjectSpawner, transform.position, Quaternion.identity);
    }

    private void ConnectController(GameObject _Object)
    {
        _Object.AddComponent<MovementInput>();
    }

    private void DisConnectController(GameObject _Object)
    {
        Destroy(_Object.GetComponent<MovementInput>());
    }

    private void InitGridBoard()
    {
        for (int y = 0; y < 21; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                GridBoard[y, x] = new Vector3(-7.0f + x * 0.5f, -5.5f + y * 0.5f, 0.0f);
                //Init Wall Setting
                if (x == 0 || x == 11) GridBoard[y, x].z = 3.0f;
                if (y == 0) GridBoard[y, x].z = 3.0f;
            }
        }
    }

    private void DeleteGridLine(int[] _iLines, bool[] _bLines)
    {
        for (int i = 0; i < _iLines.Length; i++)
        {
            if (_bLines[i])
            {
                for (int y = _iLines[i] + 1; y < 22; y++)
                {
                    for (int x = 1; x < 11; x++)
                    {
                        GridBoard[y - 1, x] = GridBoard[y, x];
                    }
                }
            }
        }
    }

    private bool[] DeleteCheckGridLines(int[] _Lines)
    {
        bool[] bDatas = new bool[4];
        for (int i = 0; i < _Lines.Length; i++)
        {
            if (_Lines[i] < 1 || _Lines[i] > 11) { bDatas[i] = false; continue; }
            for (int index = 1; index < 11; index++)
            {
                if (_Lines[index] == 0) { bDatas[i] = false; continue; }
            }
            bDatas[i] = true;
        }

        return bDatas;
    }

    private int[] CastPositionToGridIndex(float[] Positions)
    {
        int[] GridIndex = new int[Positions.Length];

        int i = 0;
        foreach(float index in Positions)
        {
            GridIndex[i] = (int)((index + 5.5f) * 2.0f);
        }    

        return GridIndex;
    }


    //private Vector2[] CastPositionToGridIndeXY(Vector2[] positions)
    //{
    //    // 그리드 인덱스를 저장할 2차원 배열 생성
    //    Vector2[] gridIndices = new Vector2[positions.Length];

    //    for (int i = 0; i < positions.Length; i++)
    //    {
    //        // 각 Vector2의 x, y 값을 그리드 인덱스로 변환하여 할당
    //        gridIndices[i].x = ((positions[i].x + 5.5f) * 2.0f); // x 값 변환
    //        gridIndices[i].y = ((positions[i].y + 7.0f) * 2.0f); // y 값 변환
    //    }

    //    return gridIndices;
    //}


    private float[] RemoveDuplicates(float[] array)
    {
        List<float> uniqueList = new List<float>();
        HashSet<float> seenValues = new HashSet<float>();

        foreach (float value in array)
        {
            if (seenValues.Add(value))
            {
                uniqueList.Add(value);
            }
        }
        return uniqueList.ToArray();
    }
}
