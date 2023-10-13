using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    PhotonView view;

    Vector2 movement;

    // Update is called once per frame
    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
            Vector3 relativeCursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", relativeCursorPosition.x);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            //Movement
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

    }
}
