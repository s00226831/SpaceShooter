using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform playerTransform;
    public float MovementSpeed = 10;
    public int Damage = 1;

    GameManager gameManager;
    Rigidbody2D body;
    Vector2 direction;

    public bool ShouldAvoid = true;
    public float avoidanceDistance = 5;
  
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        gameManager = go.GetComponent<GameManager>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }
    private void Update()
    {
        direction = playerTransform.position - transform.position;
        direction.Normalize();
        body.velocity = direction * MovementSpeed;
        transform.up = direction;;
        float closeness = Vector2.Distance(playerTransform.position, transform.position);

        if (ShouldAvoid == true & closeness <= 5 )
        {
            MovementSpeed = -1;
        }
        
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            gameManager.RecordEnemyDestroyed();
            Destroy(gameObject);
        }
    }
    
}
