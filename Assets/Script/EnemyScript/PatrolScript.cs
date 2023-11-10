
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
    private EnemyStats enemyStats;

    float xscale;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        rb = GetComponent<Rigidbody2D>();
        xscale = transform.localScale.x;
    }


    void FixedUpdate()
    {
        if (isMovingRight)
        {
            rb.velocity = new Vector2(enemyStats.Speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-enemyStats.Speed, 0f);
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
