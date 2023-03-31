using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public GameObject[] memoryObjs;
    private bool grounded;

    private void Start()
    {
        for (int i = 0; i < memoryObjs.Length; i++)
        {
            if (i == Inventory.memories)
            {
                memoryObjs[i].SetActive(true);
            }
            else {
                memoryObjs[i].SetActive(false);
            }

        }
        SavePlayerPos.LoadPosition();
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded) 
        {
            Jump();
        }
        
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            SceneManager.LoadScene("DarkScene");
        }
    }
}
