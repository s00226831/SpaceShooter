using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float moveSpeed = 10;
   public int health = 100;
   public GameObject BulletPrefab;
    public float BulletSpeed = 10;
  GameManager gameManager;
   
   float horizontal;
   float vertical;


   Rigidbody2D body;
   Vector2 velocity;
   Vector3 mousePosition;
   Vector3 direction;
   

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        gameManager = go.GetComponent<GameManager>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        velocity.x = horizontal * moveSpeed;
        velocity.y = vertical * moveSpeed;

        body.velocity = velocity;

        //Rotation
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        direction = mousePosition - transform.position;
        direction.Normalize();
        transform.up = direction;

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
        body.velocity = direction * BulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy= collision.gameObject.GetComponent<Enemy>();

            health -= enemy.Damage;
            Destroy(collision.gameObject);
            gameManager.RecordEnemyDestroyed();

            if (health <= 0)
            {
                Application.Quit();
            }
        }
    }
}
