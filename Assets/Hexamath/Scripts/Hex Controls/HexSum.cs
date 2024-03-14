using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexSum : MonoBehaviour
{
    [Header("References")]
    HexManager hexMan;
    TMP_Text textBox;

    [Header("For Sum")]
    public int sum = 0;

    [Header("Verification")]
    public bool IsComplete = false;
    [SerializeField] List<HexCell> list = new List<HexCell>();

    void Start()
    {
        hexMan = HexManager.Instance;
        textBox = GetComponentInChildren<TMP_Text>();
        textBox.text = sum.ToString();
    }

    public void CheckCompare()
    {
        int finalSum = 0;
        foreach(HexCell cell in list)
        {
            finalSum += cell.Value;
        }
        if (finalSum == sum)
        {
            IsComplete = true;

            foreach (HexCell cell in list)
            {
                cell.GreenColorChange();
            }
        }
        else
        {
            IsComplete = false;
            foreach (HexCell cell in list)
            {
                cell.WhiteColorChange();
            }
        }
    }

}
