using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool fall = false;
    public float fallTime = 1f;
    private float previousTime;
    public Vector3 rotationPoint;
    public static int height = 20;
    public static int width = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(fall == false)
            {
                transform.position += new Vector3(-0.5f, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (fall == false)
            {
                transform.position += new Vector3(0.5f, 0, 0);
            }
        }

        if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ? fallTime/10 : fallTime))
        {
            if (fall == false)
            {
                transform.position += new Vector3(0, -0.5f, 0);
                previousTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 0.5f), 90);
        }
    }
}
