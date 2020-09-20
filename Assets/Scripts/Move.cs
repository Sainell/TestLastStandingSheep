using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float RotationSpeed;
    private Vector3 moveVector;
    private bool _isGrounded;
    private Rigidbody _rigidbody;
    private float h;
    private float v;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveVector.x = h;
        moveVector.z = v;
        InputCheck(Moves());
        Jump();
        
    }

    private void InputCheck(float moveAxis)
    {
        Movement(moveAxis);
        Turn();
    }
    private float Moves()
    {
        if (moveVector.x != 0 || moveVector.z != 0)
            return 1f;
        else
            return 0f;
    }
    private void Movement(float input)
    {
        _rigidbody.AddForce(transform.forward  * input * MoveSpeed);
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, Angle360(transform.forward, moveVector, transform.right));
    }

    private float Angle360(Vector3 from, Vector3 to, Vector3 right)
    {
        float angle = Vector3.Angle(from, to);
        return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump")>0)
        {
            if(_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * JumpForce);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            _isGrounded = false;
        }
    }
}
