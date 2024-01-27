using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fall", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Fall()
    {
        transform.position -= new Vector3(0.0f, 0.5f, 0.0f);
    }
}
