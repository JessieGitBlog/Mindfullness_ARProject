using System;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;

    private void Awake()
    {
        target = UnityEngine.Camera.main.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            target.position, speed * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, target.position) == 0)
        {
            Destroy(this.gameObject);
        }
    }
}