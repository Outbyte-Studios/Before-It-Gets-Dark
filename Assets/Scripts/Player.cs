using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 500.0f;
    public float jump = 5.0f;
    public float cameraSpeed = 7.0f;
    public SpriteRenderer renderer;
    public Rigidbody2D rigidbody;
    public Transform camera;

    private float horizontal = 0.0f;

    void Start() { }

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);

        if(horizontal > 0) {
            renderer.flipX = false;
        } else {
            renderer.flipX = true;
        }

        if(Input.GetButtonDown("Jump")) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
        }
    }

    void FixedUpdate() {
        camera.position = new Vector3(Mathf.Lerp(camera.position.x, rigidbody.position.x, cameraSpeed * Time.deltaTime), Mathf.Lerp(camera.position.y, rigidbody.position.y, cameraSpeed * Time.deltaTime), camera.position.z);
    }
}
