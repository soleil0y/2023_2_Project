using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour //이름이 어쩌다 이렇게됏냐면.. 플레이어무브 임시로할라다가..
{
    public float speed = 8;
    public float jumpPower = 20;
    private bool isJumping = false;
    Rigidbody rb;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Jump();
        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        Vector3 dir = Vector3.right * h;
        transform.position += dir * speed * Time.deltaTime;

        anim.SetFloat("Move", dir.magnitude);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            anim.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7)
        {
            isJumping = false;
        }
    }

}
