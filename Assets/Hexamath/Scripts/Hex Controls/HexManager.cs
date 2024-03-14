using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HexManager : MonoBehaviour
{
    public static HexManager Instance;

    [Header("Puzzle Prefabs")]
    [SerializeField] int puzzleNumber = 0;
    [SerializeField] Transform canvasParent;
    [SerializeField] GameObject[] puzzlePrefabs;
    [SerializeField] GameObject completeButton;

    [Header("Images")]
    public Sprite ZeroSprite, OneSprite, TwoSprite, ThreeSprite;

    [Header("HexSumObject")]
    [SerializeField] List<HexSum> hexSumObjects;

    [Header("Complete Check")]
    [SerializeField] int checkCount = 0;
    public bool IsComplete = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        puzzleNumber = PlayerPrefs.GetInt(GlobalConstants.PREF_CURRENTLEVEL);
        if (puzzlePrefabs[puzzleNumber] == null)
        {
            Instantiate(puzzlePrefabs[0], canvasParent);
        }
        else
        {
            Instantiate(puzzlePrefabs[puzzleNumber], canvasParent);
        }
        hexSumObjectFinder();
    }

    void hexSumObjectFinder()
    {
        foreach (var hexSum in FindObjectsOfType<HexSum>(true))
        {
            hexSumObjects.Add(hexSum);
        }
    }

    public void HexSumChecker()
    {
        checkCount = 0;
        foreach(var hexSum in hexSumObjects)
        {
            hexSum.CheckCompare();
            if(hexSum.IsComplete)
            {
                checkCount++;
            }
        }
        if(checkCount == hexSumObjects.Count)
        {
            completeButton.SetActive(true);
            IsComplete = true;
            SoundManager.Instance.CompleteSound();
        }
    }

    public void IsCompleteButton()
    {
        if (PlayerPrefs.GetInt(GlobalConstants.PREF_CURRENTLEVEL) == PlayerPrefs.GetInt(GlobalConstants.PREF_LASTREACHEDLEVEL))
        {
            int lastLevel = PlayerPrefs.GetInt(GlobalConstants.PREF_LASTREACHEDLEVEL);
            lastLevel++;
            PlayerPrefs.SetInt(GlobalConstants.PREF_LASTREACHEDLEVEL, lastLevel);
        }
        SceneManager.LoadScene(GlobalConstants.LEVEL_MENU);
    }
}
