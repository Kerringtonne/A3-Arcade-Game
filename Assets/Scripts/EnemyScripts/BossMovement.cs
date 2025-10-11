using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;
    public float smoothTime = 0.5f;
    public Vector2 target = new Vector2(0, 2);
    Vector2 currentVelocity;

    private void Start()
    {
        StartCoroutine(MoveBoss());
    }

    IEnumerator MoveBoss()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            target = new Vector2(-3, target.y);
            yield return new WaitForSeconds(10);
            target = new Vector2(0, target.y);
            yield return new WaitForSeconds(10);
            target = new Vector2(3, target.y);
            yield return new WaitForSeconds(10);
            target = new Vector2(0, target.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
    }
}
