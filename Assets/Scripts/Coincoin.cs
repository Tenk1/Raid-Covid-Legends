using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coincoin : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource collectSound;
    //public static int piece;
    public static int coin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            collectSound.Play();
            coin++;
            //Score.score += 50;
            Destroy(gameObject);
    }
}
