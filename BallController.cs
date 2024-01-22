using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxHorizontalSpeed;
    public float vertSpeed;
    private Rigidbody2D theRB;
    public bool ballActive;
    public Transform startPoint;
    private GameManager theGM;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballActive)
        {
            theRB.velocity = Vector2.zero;
            transform.position = startPoint.position;
        }
        if (theRB.velocity.x > maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2 (maxHorizontalSpeed, theRB.velocity.y);
        } else if (theRB.velocity.x < -maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2 (-maxHorizontalSpeed, theRB.velocity.y);
        }

        Debug.Log(theRB.velocity);
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Brick")
        {
            // Destroy(other.gameObject);
            other.gameObject.GetComponent<BrickController>().DestroyBrick();
        if (theRB.velocity.y < vertSpeed)
            {
                if (theRB.velocity.y > 0)
                {
                    theRB.velocity = new Vector2 (theRB.velocity.x, vertSpeed);
                }
            }
        else if(theRB.velocity.y > -vertSpeed)
            {
                if (theRB.velocity.y < 0)
                {
                    theRB.velocity = new Vector2 (theRB.velocity.x, -vertSpeed);
                }
            }
        }
    }
    public void ActivateBall()
    {
        ballActive = true;
        theRB.velocity = new Vector2 (vertSpeed, vertSpeed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Respawn")
        {
            ballActive = false;
            theGM.RespawnBall();
        }
    }

}
