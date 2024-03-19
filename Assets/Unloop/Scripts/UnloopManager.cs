using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
    [SerializeField] List<UnloopPuzzle> lineList;
    [SerializeField] int lineCount = 0;
    [SerializeField] int verifyCount = 9;

    [Header("Transition")]
    [SerializeField] GameObject gameCompleteCanvas;
    [SerializeField] Animator fadeCanvas;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LevelSpawn();
        loopCount();
    }

    void loopCount()
    {
        lineList.Clear();
        lineList.AddRange(GameObject.FindObjectsOfType<UnloopPuzzle>());
        lineCount = lineList.Count;
    }

    public void CompleteVerification()
    {
        verifyCount = 0;
        loopCount();
        for (int i = 0;i<lineList.Count; i++)
        {
            if (lineList[i].IsComplete)
                verifyCount++;
        }
        if(verifyCount == lineCount)
        {
            levelNo++;
            fadeCanvas.SetTrigger(GlobalConstants.ANIM_FADE);
        }
    }

    public void FadeInPlay()
    {
        fadeCanvas.SetTrigger(GlobalConstants.ANIM_FADE);
    }

    public void LevelSpawn()
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
        loopCount();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
