using UnityEngine;

public class Move : MonoBehaviour
{
    private const float CAMERA_ANGLE_0 = 0f;
    private const float CAMERA_ANGLE_45 = 45f;
    private const float CAMERA_ANGLE_90 = 90f;
    private const float CAMERA_ANGLE_135 = 135f;
    private const float CAMERA_ANGLE_180 = 180f;

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

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
    }

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
        TurnAngleByCamera();
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

    private void TurnAngleByCamera()
    {
        if (v > 0)
        {
            if (h == 0)
            {
                addDir = CAMERA_ANGLE_0;
            }
            if (h < 0)
            {
                addDir = -CAMERA_ANGLE_45;
            }
            if (h > 0)
            {
                addDir = CAMERA_ANGLE_45;
            }
        }
        if (v < 0)
        {
            if (h == 0)
            {
                addDir = CAMERA_ANGLE_180;
            }
            if (h < 0)
            {
                addDir = -CAMERA_ANGLE_135;
            }
            if (h > 0)
            {
                addDir = CAMERA_ANGLE_135;
            }
        }
        if (v == 0)
        {
            if (h < 0)
            {
                addDir = -CAMERA_ANGLE_90;
            }
            if (h > 0)
            {
                addDir = CAMERA_ANGLE_90;
            }
        }

        var CurrentDirecton = transform.localEulerAngles.y;
        var TargetDirection = MainCamera.transform.localEulerAngles.y + addDir;
        var CurrentAngle = Mathf.SmoothDampAngle(CurrentDirecton, TargetDirection, ref CurrentAngleVel, 0f);
        if (isMove)
        {
            transform.localRotation = Quaternion.Euler(0, CurrentAngle, 0);
        }
    }

    private void Jump()
    {
        //PlayerPrefs.SetInt("rec", 1);

        //PlayerPrefs.GetInt("rec");

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
