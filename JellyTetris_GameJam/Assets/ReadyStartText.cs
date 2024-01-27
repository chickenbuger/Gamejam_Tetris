using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyStartText : MonoBehaviour
{
    public Text textObject; // Unity Inspector���� �ؽ�Ʈ ������Ʈ�� �Ҵ��մϴ�.

    void Start()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        // Ready �ؽ�Ʈ
        textObject.CrossFadeAlpha(1f, 0.3f, false); // ���̵���
        yield return new WaitForSeconds(0.4f); // ����
        textObject.CrossFadeAlpha(0f, 0.3f, false); // ���̵�ƿ�
        yield return new WaitForSeconds(0.5f); // ���

        // Start �ؽ�Ʈ
        textObject.text = "Start"; // �ؽ�Ʈ ����
        textObject.CrossFadeAlpha(1f, 0.3f, false); // ���̵���
        yield return new WaitForSeconds(0.4f); // ����
        textObject.CrossFadeAlpha(0f, 0.3f, false); // ���̵�ƿ�
    }
}
