using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int strawberries = 0;

    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private Text strawberriesText;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Strawberry")) {
            Destroy(collision.gameObject);
            strawberries++;
            collectSoundEffect.Play();
            strawberriesText.text = "Strawberries : " + strawberries;
        }
    }
}
