using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float speed = 2f;
    public float smoothTime = 0.5f;
    public Vector2 target = new Vector2(0, 2);
    Vector2 currentVelocity;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
    }
}
