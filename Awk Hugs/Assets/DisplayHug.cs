using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHug : MonoBehaviour
{
    [SerializeField] private HugController _hugController;
    [SerializeField] private TextMeshProUGUI hugCount;
    private void Update()
    {
        hugCount.text = _hugController.hugCount.ToString();
    }
}
