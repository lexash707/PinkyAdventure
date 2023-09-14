using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
   private int counter = 0;

   [SerializeField] private TextMeshProUGUI melonCounter;
   [SerializeField] private AudioSource collectSound;
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("melon"))
      {
         Destroy(collision.gameObject);
         collectSound.Play();
         counter++;
         melonCounter.text = "Melons: " + counter;

      }
   }
}
