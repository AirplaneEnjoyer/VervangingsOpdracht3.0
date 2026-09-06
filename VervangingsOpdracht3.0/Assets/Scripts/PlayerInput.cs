using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            OnPlayerInputRecieved.Invoke(Vector2.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            body.linearVelocityY = -5;
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.linearVelocityX = -5;
        }

        if (Input.GetKey(KeyCode.D))
        {
            body.linearVelocityX = 5;
        }
    }
    
}
