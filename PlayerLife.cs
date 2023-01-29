using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rig;
    private float coordsx;
    private float coordsy;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        coordsx = transform.position.x;
        coordsy = transform.position.y;
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rig.bodyType = RigidbodyType2D.Static;
        anim.SetBool("death", true);
    }

    public void RestartLevel()
    {
        anim.SetBool("death", false);
        rig.bodyType = RigidbodyType2D.Dynamic;
        transform.position = new Vector3(coordsx,coordsy,transform.position.z);
    }
}
