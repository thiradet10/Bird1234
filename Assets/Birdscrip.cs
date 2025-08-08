using UnityEngine;

public class Birdscrip : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float flyup = 10;
    

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rigidbody.linearVelocity = Vector2.up * flyup; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver(); 
        }
        else if (collision.gameObject.CompareTag("score"))
        {
            GameManager.instance.IncreaseScore();
        }
    }
}