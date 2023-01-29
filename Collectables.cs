using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    [SerializeField] private FloatSmores smoreScore;
    [SerializeField] private Text SmoreText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Smore"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            smoreScore.Value++;
            SmoreText.text = "Smore " + smoreScore.Value+"/4 Pieces Collected";
        }
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        { smoreScore.Value = 0; }

    }
}
