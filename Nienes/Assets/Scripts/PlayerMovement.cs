using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
   
    public Animator playerAnimator;

    public Transform player;
    public Transform target;

    public SpriteRenderer sprite;
    public Transform weapon;

    public GameObject bullet;

    private bool needMov = false;


    Vector3 mousePos;

    private void Start()
    {
        target.position = player.position;
    }

    void FixedUpdate()
    {
        if (needMov) {
            player.position = Vector3.MoveTowards(player.position, target.position, speed * Time.deltaTime);
        }

        weapon.rotation = Quaternion.AngleAxis(Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90, Vector3.forward);
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1)) { UpdateTargetPosition(); }
        else if(Input.GetMouseButton(1)) { UpdateTargetPosition(); }

        if(Input.GetMouseButton(0)) {
            Instantiate(bullet, new Vector3(weapon.position.x, weapon.position.y, 1), weapon.rotation);
        }

        playerAnimator.SetBool("isMoving", needMov);
    }

    void UpdateTargetPosition()
    {
        target.position = new Vector3(mousePos.x, mousePos.y, 1);
        needMov = true;

        if (target.position.x < player.position.x)
        {
            sprite.flipX = true;
        }
        else if (target.position.x > player.position.x)
        {
            sprite.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Target")
        {
            needMov = false;
            target.position = player.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            needMov = false;
        }
    }
}
