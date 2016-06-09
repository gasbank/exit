using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum MoveDirection { E, W, S, N, }

    public MoveDirection moveDirection = MoveDirection.E;
    public float speed = 3;
    public Rigidbody2D rb;
    public Collider2D stayedCollider;
    public int stayedFrameCount;
    public int frameCount;
    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        switch (moveDirection)
        {
            case MoveDirection.E:
                rb.velocity = new Vector2(speed, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case MoveDirection.W:
                rb.velocity = new Vector2(-speed, 0);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case MoveDirection.S:
                rb.velocity = new Vector2(0, -speed);
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case MoveDirection.N:
                rb.velocity = new Vector2(0, speed);
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Enter");
        switch (moveDirection)
        {
            case MoveDirection.E:
                moveDirection = MoveDirection.W;
                break;
            case MoveDirection.W:
                moveDirection = MoveDirection.E;
                break;
            case MoveDirection.S:
                moveDirection = MoveDirection.N;
                break;
            case MoveDirection.N:
                moveDirection = MoveDirection.S;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (frameCount == Time.frameCount)
        {
            return;
        }

        frameCount = Time.frameCount;

        if (stayedCollider != other.collider)
        {
            stayedCollider = other.collider;
            stayedFrameCount = 0;
            return;
        }

        stayedFrameCount++;

        if (stayedFrameCount > 20)
        {
            stayedFrameCount = 0;

            //Debug.Log("Enter");
            switch (moveDirection)
            {
                case MoveDirection.E:
                    moveDirection = MoveDirection.W;
                    break;
                case MoveDirection.W:
                    moveDirection = MoveDirection.E;
                    break;
                case MoveDirection.S:
                    moveDirection = MoveDirection.N;
                    break;
                case MoveDirection.N:
                    moveDirection = MoveDirection.S;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("asdf");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Exit");
    }

    // 터치 핸들러
    public void SwitchMovement()
    {
        switch (moveDirection)
        {
            case MoveDirection.E:
                moveDirection = MoveDirection.S;
                break;
            case MoveDirection.W:
                moveDirection = MoveDirection.N;
                break;
            case MoveDirection.S:
                moveDirection = MoveDirection.W;
                break;
            case MoveDirection.N:
                moveDirection = MoveDirection.E;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
