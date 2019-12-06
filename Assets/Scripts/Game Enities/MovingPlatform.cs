using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public float Speed;

    private Transform currentTarget;
    private void Start()
    {
        gameObject.transform.position = p1.position;
        currentTarget = p2;
        StartCoroutine(MoveBetweenPoints());
    }

    IEnumerator MoveBetweenPoints()
    {
        for(; ; )
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, currentTarget.position) < 1)
            {
                if(currentTarget == p1)
                {
                    currentTarget = p2;
                }
                else
                {
                    currentTarget = p1;
                }
            }
            yield return null;
        }
        yield return null;
    }
}
