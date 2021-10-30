using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 4f;
    private float jumpForce = 7f;
    private float horizontalInput;

    private int maxHP = 100;
    public int currentHP;

    public bool canJump = false;

    public Vector3 startPos;

    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rbody = GetComponent<Rigidbody>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player Walk
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    private void Update()
    {
        //Player Jump
        if (canJump && Input.GetKeyDown(KeyCode.Z))
        {
            rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump!");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DeathZone")
        {
            currentHP -= 100;
        }
        if (col.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            canJump = false;
        }
    }
}
