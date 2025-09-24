using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _jumpforce = 3f;
    float _rotationSpeed = 180f;
    //[SerializeField] Transform _cameraTransform;
    //[SerializeField] bool _shouldFaceMoveDirection;



    bool _canJump = true;

    float _moveH, _moveV;
    Vector3 _movement;
    Vector3 _moveDirection;
    Vector3 _moveSideways;
    float _rotationAmmount;
    Quaternion _turnOffset;
    Rigidbody rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        


        _moveH = Input.GetAxis("Horizontal");
        _moveV = Input.GetAxis("Vertical");

        _moveDirection = transform.forward * _moveV* _speed * Time.deltaTime;
        _moveSideways = transform.right * _moveH* _speed * Time.deltaTime;
        
        


        _movement = rb.position + _moveDirection + _moveSideways;
        rb.MovePosition(_movement);

        _rotationAmmount = _moveH * _rotationSpeed * Time.deltaTime;
        if (_rotationAmmount <= -100)
        {
            _rotationSpeed = 0;
        } else if (_rotationAmmount >= 100)
        {
            _rotationSpeed = 0;
        }
            _turnOffset = Quaternion.Euler(0, _rotationAmmount, 0);
        rb.MoveRotation(rb.rotation * _turnOffset);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 8f;
        }
        else 
        {
            _speed = 3f;
        }

        if (Input.GetButton("Jump") && _canJump)
        {
            rb.linearVelocity += (Vector3.up * _jumpforce);
        }


        //Vector3 forward = _cameraTransform.forward;
        //Vector3 right = _cameraTransform.right;

        //forward.y = 0;
        //right.y = 0;

        //forward.Normalize();
        //right.Normalize();

        //Vector3 lookDirection = forward * _moveV + right * _moveH;
        //rb.MovePosition(lookDirection * _speed * Time.deltaTime);

        //if (_shouldFaceMoveDirection && lookDirection.sqrMagnitude > 0.001f) 
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        { 
            _canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _canJump = false;
        }
    }

 
}
