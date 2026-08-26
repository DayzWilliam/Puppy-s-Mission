using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMove = 0f;

    public float speed = 40f;
    [SerializeField] private bool jumping = false;
    [SerializeField] private bool crouching = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
;
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouching = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouching = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, crouching, jumping);
        jumping = false;
    }
}
