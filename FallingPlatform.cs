using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float destroyDelay = 2f;
    [SerializeField] private AudioSource breaking;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 coords;

    private void Start()
    {
        coords = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        breaking.Play();
        rb.bodyType = RigidbodyType2D.Dynamic;
        Invoke("Reset", 5);
    }

    private void Reset()
    {
        transform.position = coords;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
