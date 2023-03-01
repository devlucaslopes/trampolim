using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float Multiplier;

    private Animator anim;

    private Player _player;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerJump()
    {
        if (_player != null)
        {
            _player.JumpFromTrampoline(Multiplier);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _player = collision.gameObject.GetComponent<Player>();
            anim.SetTrigger("jump");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _player = null;
            
        }
    }
}
