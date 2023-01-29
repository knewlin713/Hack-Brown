using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Campfire : MonoBehaviour
{
    public GameObject Global;
    private bool boolean = false;
    public GameObject CampFire;
    private Vector3 coords;

    [SerializeField] private AudioSource endLevelSound;
    private bool isLevelDone = false;
    private void Start()
    {
        coords = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isLevelDone)
        {
            GlobalLighting.Increase();
            Instantiate(CampFire,coords, Quaternion.identity);
            endLevelSound.Play();
            isLevelDone = true;
            Invoke("CompleteLevel", 3f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
