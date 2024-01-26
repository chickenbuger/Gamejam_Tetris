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
                transform.position += new Vector3(-1, 0, 0);
                //if (!ValidMove())
                //{
                //    transform.position -= new Vector3(-1, 0, 0);
                //}
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (fall == false)
            {
                transform.position += new Vector3(1, 0, 0);
                //if (!ValidMove())
                //{
                //    transform.position -= new Vector3(1, 0, 0);
                //}
            }
        }

        if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ? fallTime/10 : fallTime))
        {
            if (fall == false)
            {
                transform.position += new Vector3(0, -1, 0);
                previousTime = Time.time;
                //if (!ValidMove())
                //{
                //    transform.position -= new Vector3(0, -1, 0);
                //}
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            //if(!ValidMove())
            //{
            //    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            //}
        }
    }

    //bool ValidMove()
    //{
    //    foreach(Transform childrenin in transform)
    //    {
    //        int roundX = Mathf.RoundToInt(childrenin.transform.position.x);
    //        int roundY = Mathf.RoundToInt(childrenin.transform.position.y);

    //        if(roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
}
