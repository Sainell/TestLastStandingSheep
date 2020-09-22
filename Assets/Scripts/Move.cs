using UnityEngine;

public class Move : MonoBehaviour
{
    private const float CAMERA_LOW_SIDE_ANGLE = 0f;
    private const float CAMERA_HALF_SIDE_ANGLE = 90f;
    private const float CAMERA_BACK_SIDE_ANGLE = 225f;
    private const float CAMERA_BACK_ANGLE = 180f;

    public float MoveSpeed;
    public float JumpForce;
    public float RotationSpeed;
    public GameObject MainCamera;
    public Vector3 curVector;
    public bool isMove;
    private Vector3 moveVector;
    private Camera _camera;
    private bool _isGrounded;
    private Rigidbody _rigidbody;
    private Animator _animator;
    public float h;
    public float v;
    private float addDir;
    private float CurrentAngleVel;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
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
    private void Animator()
    {
        _animator.Play("Sheep|Walk");
    }
    private void InputCheck(float moveAxis)
    {
        Movement(moveAxis);
     //   Turn(moveAxis);
        AngleByCamera(moveAxis);
    }
    private float Moves()
    {
        if (moveVector.x != 0 || moveVector.z != 0)
        {
            isMove = true;
            return 1f;
        }

        else
        {
            isMove = false;
            return 0f;
        }
    }
    private void Movement(float input)
    {
        _rigidbody.AddForce(transform.forward  * input * MoveSpeed, ForceMode.Impulse);
    }

    //private void Turn(float input)
    //{
    //     transform.Rotate(Vector3.up, Angle360(transform.forward, moveVector, transform.right)*RotationSpeed * Time.deltaTime);
    //}

    private void AngleByCamera(float input)
    {


        if (v > 0)
        {
            if (h == 0)
            {
                addDir = 0f;
            }
            if (h < 0)
            {
                addDir = -45f;
            }
            if (h > 0)
            {
                addDir = 45f;
            }
        }
        if (v < 0)
        {
            if (h == 0)
            {
                addDir = 180f;
            }
            if (h < 0)
            {
                addDir = -135f;
            }
            if (h > 0)
            {
                addDir = 135f;
            }
        }
        if (v == 0)
        {
            if (h < 0)
            {
                addDir = -90f;
            }
            if (h > 0)
            {
                addDir = 90f;
            }
        }

        var CurrentDirecton = transform.localEulerAngles.y;
        var TargetDirection = MainCamera.transform.localEulerAngles.y + addDir;
        var CurrentAngle = Mathf.SmoothDampAngle(CurrentDirecton, TargetDirection, ref CurrentAngleVel, 0.1f);
        if (isMove)
        {
            transform.localRotation = Quaternion.Euler(0, CurrentAngle, 0);
        }
    }
    //private float Angle360(Vector3 from, Vector3 to, Vector3 right)
    //{
    //    float angle = Vector3.Angle(from, to);
    //    return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
    //}

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
