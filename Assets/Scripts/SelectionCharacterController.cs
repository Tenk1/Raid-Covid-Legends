using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionCharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 newPose;
    public static bool SelectMove;
    public Transform selectionContainer;
    public float lerpTime;
    public Text coinText, prixJotaroText, prixBombermanText, prixTrooperText;
    public Image pqJotaro, pqTrooper, pqBomberman;
    public static int[] cost = new int[4] { 0, 50, 100, 150 };


    // Update is called once per frame
    void Update()
    {

        prixJotaroText.text = cost[1].ToString();
        prixTrooperText.text = cost[2].ToString();
        prixBombermanText.text = cost[3].ToString();
        
        coinText.text = "" + (PlayerPrefs.GetInt("Coin")).ToString();
        if (selectionContainer.position != newPose && SelectMove)
        {
            selectionContainer.position = Vector3.Lerp(selectionContainer.position, newPose, lerpTime * Time.deltaTime);
        }
        if(Vector3.Distance(selectionContainer.position, newPose) < .1f)
        {
            selectionContainer.position = newPose;
            SelectMove = false;
        }

        if(PlayerPrefs.GetInt("Jotaro") == 1)
        {
            prixJotaroText.enabled = false;
            pqJotaro.enabled = false;
        }
        if (PlayerPrefs.GetInt("Bomberman") == 1)
        {
            prixBombermanText.enabled = false;
            pqBomberman.enabled = false;
        }
        if (PlayerPrefs.GetInt("Trooper") == 1)
        {
            prixTrooperText.enabled = false;
            pqTrooper.enabled = false;
        }
    }
}
