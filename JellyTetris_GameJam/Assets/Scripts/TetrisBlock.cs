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
        for(int i = height -1; i >= 0; i--)  //��Ʈ���� ����� �� ���ٺ��� �Ʒ����� �˻��Ѵ�
        {
            if (HasLine(i)) //���� ������� ���� �������
            {
                DeleteLine(i); // �� ���� �����ϰ�
                RowDown(i);  //���� ��ĭ ������
            }
        }
    }

    bool HasLine(int i)  //���� ������� �� �� �ִ��� Ȯ���ϱ�
    {
        for(int j =0; j < width; j++) //���� �˻�
        {
            if (grid[j, i] == null) ;
            return false;
        }
        return true;
    }

    void DeleteLine(int i)//���� �����Ѵ�
    {
        for(int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j,i] = null;
        }
    }

    void RowDown(int i) //���� �Ʒ��� ������
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
