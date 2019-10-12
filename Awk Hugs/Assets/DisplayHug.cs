using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHug : MonoBehaviour
{
    [SerializeField] private HugController _hugController;
    [SerializeField] private TextMeshProUGUI hugCountText;
    [SerializeField] private int hugCount = 0;

    private void Start()
    {
        _hugController.OnSuccessfulHug += HandleSuccessfulHug;
    }

    private void HandleSuccessfulHug()
    {
        hugCount++;
        hugCountText.text = hugCount.ToString();
    }
}
