using UnityEngine;

public class FadeText : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    private float timer = 0.0f;
    private CanvasGroup canvasGroup;
    private bool fadingOut = true;

    void Start()
    {
        // CanvasGroup ������Ʈ�� ���ٸ� �߰�
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // �ʱ� ���� ����
        canvasGroup.alpha = 1.0f;
    }

    void Update()
    {
        // Ÿ�̸� ������Ʈ
        timer += Time.deltaTime;

        // ���̵� ��/�ƿ� ����
        float normalizedTime = Mathf.Clamp01(timer / fadeDuration);
        canvasGroup.alpha = fadingOut ? 1.0f - normalizedTime : normalizedTime;

        // 3�ʰ� ������ Ÿ�̸� �ʱ�ȭ �� ���̵� ���� ��ȯ
        if (timer >= fadeDuration)
        {
            timer = 0.0f;
            fadingOut = !fadingOut;
        }
    }
}
