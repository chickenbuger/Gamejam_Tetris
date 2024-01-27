using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explose : MonoBehaviour
{
    public float bounceForce = 0.11f;

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Rigidbody�� �ִٸ�
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // �浹�� ������Ʈ�� �̸��� ������
            string collidedObjectName = collision.collider.gameObject.name;

            // ���� ������Ʈ�� �̸��� ������
            string thisObjectName = gameObject.name;

            // ���� �̸��� ������Ʈ������ ������ �ʰ� ��
            if (collidedObjectName != thisObjectName)
            {
                // �浹�� �������� ƨ��� ���� ����
                Vector3 bounceDirection = (collision.contacts[0].point - transform.position).normalized;
                rb.AddForce(bounceDirection * bounceForce);
            }
        }
    }
}
