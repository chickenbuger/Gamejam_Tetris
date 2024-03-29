using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

    private void Update()
    {
        CheckForLines();
    }
    void CheckForLines()
    {
        for(int i = height -1; i >= 0; i--)  //테트리스 블록을 맨 윗줄부터 아래까지 검색한다
        {
            if (HasLine(i)) //줄이 블록으로 꽉차 있을경우
            {
                DeleteLine(i); // 그 줄을 삭제하고
                RowDown(i);  //줄을 한칸 내린다
            }
        }
    }

    bool HasLine(int i)  //줄이 블록으로 꽉 차 있는지 확인하기
    {
        for(int j =0; j < width; j++) //줄을 검색
        {
            if (grid[j, i] == null) ;
            return false;
        }
        return true;
    }

    void DeleteLine(int i)//줄을 삭제한다
    {
        for(int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j,i] = null;
        }
    }

    void RowDown(int i) //줄을 아래로 내린다
    {
        for(int y = i; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                if (grid[j,i] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}
