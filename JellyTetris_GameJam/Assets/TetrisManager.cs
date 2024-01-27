using UnityEngine;

public class TetrisManager : MonoBehaviour
{
    // ���� ������ ��� �� ��
    public int rows = 12;
    public int columns = 21;

    // ��� ������
    public GameObject blockPrefab;

    // ���� ���带 ��Ÿ���� 2D �迭
    private Transform[,] grid;

    void Start()
    {
        // ���� ���� �ʱ�ȭ
        grid = new Transform[rows, columns];

        // �׸��� ũ�⸦ (0.5, 0.5, 0)���� �����ϰ�, Ư�� ��ǥ�� �������� ���� ���带 ��ġ��Ű��
        transform.localScale = new Vector3(0.5f, 0.5f, 0);
        transform.position = new Vector3(-7, -5.5f, 0);

        // �ʱ� ��� ����
        SpawnBlock();
    }

    void SpawnBlock()
    {
        // TODO: ������ ��ġ���� ��� ���� ����
        // ����� ������ ��ġ�� ���� ������ grid �迭�� ����
    }

    void Update()
    {
        // �� �����Ӹ��� ���� üũ
        CheckLines();
    }

    void CheckLines()
    {
        // �� ���� Ȯ���Ͽ� �� �� ���� �ִ��� �˻�
        for (int i = 0; i < rows; i++)
        {
            if (IsLineFull(i))
            {
                // �� �� ���� ����� ���� ��ϵ��� �Ʒ��� �̵�
                ClearLine(i);
                MoveLinesDown(i);
            }
        }
    }

    bool IsLineFull(int row)
    {
        // Ư�� ���� �� á���� Ȯ��
        for (int j = 0; j < columns; j++)
        {
            if (grid[row, j] == null)
            {
                // �� ���� ������ �� ���� ����
                return false;
            }
        }
        // ��� ���� ������� ä���� ������ �� ��
        return true;
    }

    void ClearLine(int row)
    {
        // �� �� ���� ��� ����
        for (int j = 0; j < columns; j++)
        {
            Destroy(grid[row, j].gameObject);
            grid[row, j] = null;
        }
    }

    void MoveLinesDown(int clearedRow)
    {
        // ������ �� ���� ��� ���� �Ʒ��� �̵�
        for (int i = clearedRow; i < rows - 1; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (grid[i + 1, j] != null)
                {
                    // ����� �Ʒ��� �̵�
                    grid[i, j] = grid[i + 1, j];
                    grid[i + 1, j] = null;
                    grid[i, j].position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}
