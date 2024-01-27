using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridIndeXY : MonoBehaviour
{
    public Vector2 CastPositionToGridIndexXY(Vector2 position)
    {
        // �׸��� �ε����� ������ Vector2 ����
        Vector2 gridIndices = new Vector2();

        // x, y ���� �׸��� �ε����� ��ȯ�Ͽ� �Ҵ�
        gridIndices.x = (int)((position.x + 5.5f) * 2.0f); // x �� ��ȯ
        gridIndices.y = (int)((position.y + 7.0f) * 2.0f); // y �� ��ȯ

        return gridIndices;
    }
}
