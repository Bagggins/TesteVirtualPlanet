using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offSet;

    void FixedUpdate ()
    {
        Vector3 desirePosition = target.position + offSet;
        Vector3 smoothedPos = Vector3.Lerp (transform.position, desirePosition, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(target);
    }

}
