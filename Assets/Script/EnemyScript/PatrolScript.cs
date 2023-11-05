
using Assets;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PatrolScript : MonoBehaviour
{

    public bool isMovingRight = true;
    private Rigidbody2D rb;
    public Transform leftEnd;
    public Transform rightEnd;
    public float speed = 2f;

    float xscale;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        xscale = transform.localScale.x;
    }


    void FixedUpdate()
    {
        if (isMovingRight)
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0f);
        }

        if (transform.position.x > rightEnd.position.x)
        {
            isMovingRight = false;
        }
        if (transform.position.x < leftEnd.position.x)
        {
            isMovingRight = true;
        }

        GameService.Instance.isFlip(rb, transform, xscale);
    }


}
