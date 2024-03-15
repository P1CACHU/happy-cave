using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
        private void OnTriggerEnter2D (Collider2D col)
        {
         Debug.Log("collision");

         var apple = col.gameObject.GetComponent <Apple>();
    if
    (apple!=null)
    { 
    var pos = Camera.main.ScreenToWorldPoint (FindObjectOfType <scoreCounter>().transform .position);
       apple.transform.DOMove (pos, 1.0f).OnComplete(()=>{Destroy(apple.gameObject);});
      
    }
    
   }
   
    } 
    
}
