using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float speed;
    public float direction;
    public float adjustSpeed;
    public Transform rightBound;
    public Transform leftBound;
        // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            transform.position = new Vector3(transform.position.x+(speed*Time.deltaTime),transform.position.y,transform.position.z);
            direction = 1;
        } else if(Input.GetKey(KeyCode.A)){
            transform.position = new Vector3(transform.position.x-(speed*Time.deltaTime),transform.position.y,transform.position.z);
            direction = -1;
        } else {
            direction = 0;
        }
        if(transform.position.x > rightBound.position.x)
        {
            transform.position = new Vector3(rightBound.position.x,transform.position.y,transform.position.z);
        }
        else if(transform.position.x < leftBound.position.x)
        {
            transform.position = new Vector3(leftBound.position.x,transform.position.y,transform.position.z);
        }
    }
    void OnCollisionExit2D(Collision2D other){
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x+((direction*adjustSpeed)), other.rigidbody.velocity.y);
        Debug.Log(other.rigidbody.velocity);
    }
}
