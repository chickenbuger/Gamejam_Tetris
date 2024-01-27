using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explose : MonoBehaviour
{
    public float bounceForce = 0.11f;

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트에 Rigidbody가 있다면
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 충돌한 오브젝트의 이름을 가져옴
            string collidedObjectName = collision.collider.gameObject.name;

            // 현재 오브젝트의 이름을 가져옴
            string thisObjectName = gameObject.name;

            // 같은 이름의 오브젝트끼리는 터지지 않게 함
            if (collidedObjectName != thisObjectName)
            {
                // 충돌한 방향으로 튕기는 힘을 가함
                Vector3 bounceDirection = (collision.contacts[0].point - transform.position).normalized;
                rb.AddForce(bounceDirection * bounceForce);
            }
        }
    }
}
