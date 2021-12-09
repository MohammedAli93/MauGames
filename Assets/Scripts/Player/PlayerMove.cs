using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{


    bool alive = true;
    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float leftRightSpeed = 4f;

    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplayer = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {

        if (!alive)
            return;
        Vector3 forwardMove = transform.forward * moveSpeed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * moveSpeed * Time.fixedDeltaTime * horizontalMultiplayer;
                        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundiers.leftSide)
            {
                rb.MovePosition(rb.position + forwardMove + horizontalMove);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundiers.rightSide)
            {
                rb.MovePosition(rb.position + forwardMove + horizontalMove);
            }
        }
        // rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     if (this.gameObject.transform.position.x > LevelBoundiers.leftSide)
        //     {
        //         transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        //     }
        // }
        // if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // {
        //     if (this.gameObject.transform.position.x < LevelBoundiers.rightSide)
        //     {
        //         transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
        //     }
        // }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
