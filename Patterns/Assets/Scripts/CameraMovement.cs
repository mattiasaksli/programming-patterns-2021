using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private MapInfo map;
    private Camera cam;

    void Start()
    {
        map = FindObjectOfType<MapInfo>();
        cam = GetComponentInChildren<Camera>();
        if (cam == null)
            enabled = false;
    }

    // LateUpdate is called once at the end of frame
    void LateUpdate()
    {
        if(target == null)
            return;

        Vector3 targetPositon = target.position;
        if (map != null)
        {
            targetPositon = map.ClampPosition(targetPositon, 
                new Vector2(cam.orthographicSize * cam.aspect, cam.orthographicSize));
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPositon, speed * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void JumpToTarget()
    {
        if(target == null)
            return;

        transform.position = target.position;
    }
}
