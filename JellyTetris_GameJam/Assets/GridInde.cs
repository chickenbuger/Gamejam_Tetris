using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInde : MonoBehaviour
{
    public GridIndeXY gridIndeXY;

    void Start()
    {
    }

    public void CastPositionToGridIndeXY(Vector2[] positions)
    {
        // �׸��� �ε����� ������ �迭 ����
        Vector2[] gridIndices = new Vector2[positions.Length];

        // �� Vector2�� x, y ���� �׸��� �ε����� ��ȯ�Ͽ� �Ҵ�
        for (int i = 0; i < positions.Length; i++)
        {
            gridIndices[i] = gridIndeXY.CastPositionToGridIndexXY(positions[i]);
        }
        GameObject findInde= GameObject.Find("GameMode");
        GameMode gameMode = findInde.GetComponent<GameMode>();
        gameMode.RequestGridIndexXY(gridIndices,this.gameObject);
    }
}
