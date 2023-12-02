using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public enum State
    { 
        Chasing,
        Attacking1,
        Attacking2,
        Attacking3,
    }

    public Rigidbody2D rb;
    public Transform player;
    public Vector2 distance;
    public State currentState;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        player = GameObject.Find("Player").GetComponent<Transform>();
        currentState = State.Chasing;
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
           
            case State.Chasing:
                Chasing();
                break;
            case State.Attacking1:
                Attacking1();
                break;
            case State.Attacking2:
                Attacking2();
                break;
            case State.Attacking3:
                Attacking3();
                break;
          
        }
        
    }
    public void Chasing() 
    {
        distance = Vector2.MoveTowards(rb.position, player.position, 5f * Time.fixedDeltaTime);

        rb.MovePosition(distance);

        if (Mathf.Abs(transform.position.x - player.position.x) <= 2.5f) currentState = State.Attacking1;
    }   
    public void Attacking1() 
    {
        Debug.Log(currentState);
    }
    public void Attacking3()
    {
        Debug.Log(currentState);

    }
    public void Attacking2()
    {
        Debug.Log(currentState);

    }

}
