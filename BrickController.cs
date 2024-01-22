using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int brickValue;
    private GameManager theGM;
    public GameObject scoreEffect;
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {}
    public void DestroyBrick()
    {
        theGM.AddScore(brickValue);
        Instantiate(scoreEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
