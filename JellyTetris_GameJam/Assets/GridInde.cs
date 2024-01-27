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
        // 그리드 인덱스를 저장할 배열 생성
        Vector2[] gridIndices = new Vector2[positions.Length];

        // 각 Vector2의 x, y 값을 그리드 인덱스로 변환하여 할당
        for (int i = 0; i < positions.Length; i++)
        {
            gridIndices[i] = gridIndeXY.CastPositionToGridIndexXY(positions[i]);
        }
        GameObject findInde= GameObject.Find("GameMode");
        GameMode gameMode = findInde.GetComponent<GameMode>();
        gameMode.RequestGridIndexXY(gridIndices,this.gameObject);
    }
}
