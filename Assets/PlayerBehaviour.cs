using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public LayerMask GroundMask;
    public float RaycastDistance;
    public Transform RaycastOriginDown;
    public Transform RaycastOriginDownLeft;
    public Transform RaycastOriginDownRight;
    private bool _isGrounded;
    private bool _isTouchingTop;
    public Rigidbody2D PlayerRigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        forward();
        RaycastHit2D hitD = Physics2D.Raycast(RaycastOriginDown.position, Vector2.down, RaycastDistance, GroundMask);
        RaycastHit2D hitDL = Physics2D.Raycast(RaycastOriginDownLeft.position, Vector2.down, RaycastDistance, GroundMask);
        RaycastHit2D hitDR = Physics2D.Raycast(RaycastOriginDownRight.position, Vector2.down, RaycastDistance, GroundMask);
        RaycastHit2D hitT = Physics2D.Raycast(RaycastOriginDown.position, Vector2.up, RaycastDistance, GroundMask);
        RaycastHit2D hitTL = Physics2D.Raycast(RaycastOriginDownLeft.position, Vector2.up, RaycastDistance, GroundMask);
        RaycastHit2D hitTR = Physics2D.Raycast(RaycastOriginDownRight.position, Vector2.up, RaycastDistance, GroundMask);
        _isGrounded = hitD.collider != null || hitDL.collider != null || hitDR.collider != null;
        _isTouchingTop = hitT.collider != null || hitTL.collider != null || hitTR.collider != null;

        if (_isGrounded || _isTouchingTop)
            PlayerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        if ((Input.GetKeyDown(KeyCode.Space) && _isGrounded) || (Input.GetKeyDown(KeyCode.Space) && _isTouchingTop))
        {
            if (_isGrounded)
                PlayerRigidbody.AddForce(Vector2.up * JumpForce);
            if (_isTouchingTop)
                PlayerRigidbody.AddForce(Vector2.down * JumpForce);
        }
    }

    private void forward()
    {
        PlayerRigidbody.velocity = new Vector2(Speed, PlayerRigidbody.velocity.y);
    }
}
