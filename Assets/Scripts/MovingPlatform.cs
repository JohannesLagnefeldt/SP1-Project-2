using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform target1, target2;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitTime;

    private Transform current_target;
    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        current_target = target1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {

            if (transform.position == current_target.position)
            {
                waiting = true;
                Invoke("change_target", waitTime);
            }
            transform.position = Vector2.MoveTowards(transform.position, current_target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void change_target()
    {
        if(current_target == target1)
        {
            current_target = target2;
        }
        else if (current_target == target2)
        {
            current_target = target1;
        }
        waiting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
