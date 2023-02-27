using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Jump;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector3 _jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        _jumpForce = Vector3.up * Jump;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(_jumpForce, ForceMode2D.Impulse);
        }    
    }

    private void FixedUpdate()
    {
        float _direction = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(_direction * Speed, rb.velocity.y);

        if (_direction != 0)
        {
            anim.SetInteger("transition", 1);
        } else
        {
            anim.SetInteger("transition", 0);
        }

        if (_direction > 0)
        {
            transform.eulerAngles = Vector3.zero;
        } else if (_direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
