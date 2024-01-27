using UnityEngine;

public class TetrisManager : MonoBehaviour
{
    // 게임 보드의 행과 열 수
    public int rows = 12;
    public int columns = 21;

    // 블록 프리팹
    public GameObject blockPrefab;

    // 게임 보드를 나타내는 2D 배열
    private Transform[,] grid;

    void Start()
    {
        // 게임 보드 초기화
        grid = new Transform[rows, columns];

        // 그리드 크기를 (0.5, 0.5, 0)으로 설정하고, 특정 좌표를 기준으로 게임 보드를 위치시키기
        transform.localScale = new Vector3(0.5f, 0.5f, 0);
        transform.position = new Vector3(-7, -5.5f, 0);

        // 초기 블록 생성
        SpawnBlock();
    }

    void SpawnBlock()
    {
        // TODO: 랜덤한 위치에서 블록 생성 로직
        // 블록이 생성된 위치에 대한 정보를 grid 배열에 저장
    }

    void Update()
    {
        // 매 프레임마다 라인 체크
        CheckLines();
    }

    void CheckLines()
    {
        // 각 행을 확인하여 꽉 찬 줄이 있는지 검사
        for (int i = 0; i < rows; i++)
        {
            if (IsLineFull(i))
            {
                // 꽉 찬 줄을 지우고 위의 블록들을 아래로 이동
                ClearLine(i);
                MoveLinesDown(i);
            }
        }
    }

    bool IsLineFull(int row)
    {
        // 특정 행이 꽉 찼는지 확인
        for (int j = 0; j < columns; j++)
        {
            if (grid[row, j] == null)
            {
                // 빈 셀이 있으면 꽉 차지 않음
                return false;
            }
        }
        // 모든 셀이 블록으로 채워져 있으면 꽉 참
        return true;
    }

    void ClearLine(int row)
    {
        // 꽉 찬 줄의 블록 제거
        for (int j = 0; j < columns; j++)
        {
            Destroy(grid[row, j].gameObject);
            grid[row, j] = null;
        }
    }

    void MoveLinesDown(int clearedRow)
    {
        // 지워진 행 위의 모든 행을 아래로 이동
        for (int i = clearedRow; i < rows - 1; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (grid[i + 1, j] != null)
                {
                    // 블록을 아래로 이동
                    grid[i, j] = grid[i + 1, j];
                    grid[i + 1, j] = null;
                    grid[i, j].position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}
