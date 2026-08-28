using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float horizontalMove = 0f;

    public float speed = 40f;
    [SerializeField] private bool jumping = false;
    [SerializeField] private bool crouching = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouching = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouching = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, crouching, jumping);
        jumping = false;
    }
}
