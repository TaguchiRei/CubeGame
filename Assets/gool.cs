using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gool : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.time = 1;
        AudioSource.Play();
    }
}
