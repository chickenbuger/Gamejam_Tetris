using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridIndeXY : MonoBehaviour
{
    public Vector2 CastPositionToGridIndexXY(Vector2 position)
    {
        // 그리드 인덱스를 저장할 Vector2 생성
        Vector2 gridIndices = new Vector2();

        // x, y 값을 그리드 인덱스로 변환하여 할당
        gridIndices.x = (int)((position.x + 5.5f) * 2.0f); // x 값 변환
        gridIndices.y = (int)((position.y + 7.0f) * 2.0f); // y 값 변환

        return gridIndices;
    }
}
