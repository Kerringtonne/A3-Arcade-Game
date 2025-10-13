using System.Collections;
using UnityEngine;

public class BossMovement3 : MonoBehaviour
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
            smoothTime = 1;
            yield return new WaitForSeconds(10);
            target = new Vector2(0, 1.5f);
            yield return new WaitForSeconds(10);
            target = new Vector2(0, 3f);
            yield return new WaitForSeconds(10);
            target = new Vector2(-3, 3);
            yield return new WaitForSeconds(10);
            target = new Vector2(3, 3);
            yield return new WaitForSeconds(10);
            target = new Vector2(0, 1.5f);
            yield return new WaitForSeconds(5);
            target = new Vector2(-3, 3);
            smoothTime = 3;
            yield return new WaitForSeconds(5);
            target = new Vector2(3, 3);
            yield return new WaitForSeconds(5);
            target = new Vector2(-3, 3);
            yield return new WaitForSeconds(5);
            target = new Vector2(3, 3);
            yield return new WaitForSeconds(10);
            target = new Vector2(0, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
    }
}
