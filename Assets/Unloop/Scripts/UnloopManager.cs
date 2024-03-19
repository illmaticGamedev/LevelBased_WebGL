using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloopManager : MonoBehaviour
{
    public static UnloopManager Instance;

    [Header("Level Spawn")]
    [SerializeField] List<GameObject> levels;
    [SerializeField] int levelNo = 0;
    GameObject currentLevel = null;

    [Header("Unloop Puzzle")]
    [SerializeField] UnloopPuzzle[] lineList;
    [SerializeField] int lineCount = 0;
    [SerializeField] int verifyCount = 9;
    [SerializeField] GameObject gameCompleteCanvas;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        levelSpawn();
        loopCount();
    }

    void loopCount()
    {
        lineList = FindObjectsOfType<UnloopPuzzle>();
        lineCount = lineList.Length;
    }

    public void completeVerification()
    {
        verifyCount = 0;
        for (int i = 0;i<lineList.Length;i++)
        {
            if (lineList[i].IsComplete)
                verifyCount++;
        }
        if(verifyCount == lineCount)
        {
            levelNo++;
            levelSpawn();
        }
    }

    void levelSpawn()
    {
        if(levelNo == levels.Count)
        {
            gameCompleteCanvas.SetActive(true);
        }
        else
        {
        if(currentLevel!= null)
        Destroy(currentLevel.gameObject);
        currentLevel = Instantiate(levels[levelNo]);
        lineList = null;
        loopCount();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
