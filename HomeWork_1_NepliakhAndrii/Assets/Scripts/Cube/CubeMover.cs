using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;
    
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 velocity = Vector3.zero; 
        
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity += Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity += Vector3.back * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity += Vector3.right * speed;
        }
    }
}
