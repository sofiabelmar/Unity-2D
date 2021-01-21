using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{
  Animator anim;
  SpriteRenderer spr;
  [SerializeField, Range(0.0f,20f)]
  float moveSpeed = 2;

    [SerializeField, Range(0.1f,15f)]
  float jumpforce;

[SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 15f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;


  Rigidbody2D rb2D;

  void Awake()
  {
      anim = GetComponent<Animator>();
      spr = GetComponent<SpriteRenderer>();
      rb2D = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
      transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
      spr.flipX = Flip;
     
     
  }
    //para las cosas físicas
    void FixedUpdate()
    {
        if (jumpButton && IsGrounding)
            {
                rb2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                anim.SetTrigger("jump");
            }
    }

  void LateUpdate()
  {
      anim.SetFloat("moveX",Mathf.Abs(Axis.x));
      anim.SetBool("grounding", IsGrounding);
  }

  Vector2 Axis
  {
      get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
  }

  bool Flip
  {
      get => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
  }

  bool jumpButton => Input.GetButtonDown("Jump");

  bool IsGrounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance,groundLayer);

  void OnDrawGizmosSelected()
  {
      Gizmos.color = rayColor;
      Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
  }
}
