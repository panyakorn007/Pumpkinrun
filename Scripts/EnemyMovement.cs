using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed = 1;
    public int xMove = 1;//ตัวแปรกำหนดทิศทางเคลื่อนที่
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit=Physics2D.Raycast(transform.position,new Vector2(xMove,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove,0)*speed;
    }
}
