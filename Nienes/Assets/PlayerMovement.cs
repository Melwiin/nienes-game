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

    private bool needMov = false;
    

    private void Start()
    {
        target.position = player.position;
    }

    void FixedUpdate()
    {
        if (needMov) {
            player.position = Vector3.MoveTowards(player.position, target.position, speed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) { UpdateTargetPosition(); }
        else if(Input.GetMouseButton(1)) { UpdateTargetPosition(); }

        playerAnimator.SetBool("isMoving", needMov);
    }

    void UpdateTargetPosition()
    {
        Vector3 newTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.position = new Vector3(newTargetPosition.x, newTargetPosition.y, 1);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Target")
        {
            needMov = false;
            target.position = player.position;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Target")
        {
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
    }
}
