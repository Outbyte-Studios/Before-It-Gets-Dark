using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 10.0f;
    public float jump = 8.0f;
    public float cameraSpeed = 7.0f;
    public SpriteRenderer renderer;
    public Rigidbody2D rigidbody;
    public Transform camera;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    public SpriteRenderer health;
    public SpriteRenderer temperature;

    private float horizontal = 0.0f;
    private bool isGrounded = false;

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
       
        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));

        if (horizontal > 0) {
            renderer.flipX = false;
        } else {
            renderer.flipX = true;
        }

        if(Input.GetButtonDown("Jump") && isGrounded) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
        }

        if(Input.GetKey(KeyCode.G)) {
            health.size -= new Vector2(0.01f, 0.0f);
        }
        
        if(Input.GetKey(KeyCode.H)) {
            temperature.size -= new Vector2(0.01f, 0.0f);
        }

        if(health.size.x > 1.7f) {
            health.size = new Vector2(1.7f, 0.4f);
        }

        if(temperature.size.x > 1.7f) {
            temperature.size = new Vector2(1.7f, 0.4f);
        }
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        camera.position = new Vector3(Mathf.Lerp(camera.position.x, rigidbody.position.x, cameraSpeed * Time.deltaTime), Mathf.Lerp(camera.position.y, rigidbody.position.y, cameraSpeed * Time.deltaTime), camera.position.z);
    }
}
