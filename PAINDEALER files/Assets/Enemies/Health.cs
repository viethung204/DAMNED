using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    public float health = 50f;
    private Animator EnemyAnimator;
    private Transform Player;
    public float deceleration = 1.5f;
    public float travelSpeed = 1.5f;


    /*public BoxCollider Collider;
    public float newColliderX;
    public float newColliderY;*/

    private void Start()
    {
        EnemyAnimator = this.gameObject.GetComponent<Animator>();
        Player = (GameObject.Find("Capsule")).gameObject.GetComponent<Transform>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        EnemyAnimator.SetTrigger("isHurt");
    }

    public void Update()
    {
        if (health <= 0f)
        {
            EnemyAnimator.SetBool("died", true);
            gameObject.tag = "Untagged";
            transform.position = Vector3.MoveTowards(transform.position, transform.position += Player.forward, travelSpeed * Time.deltaTime);
            if ((travelSpeed -= deceleration * Time.deltaTime) <= 0)
            {
                travelSpeed = 0;
            }
        }
    }
}
