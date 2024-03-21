using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillHoleManager : MonoBehaviour
{
    public static FillHoleManager Instance;

    [Header("Level Spawn")]
    [SerializeField] List<GameObject> levels;
    [SerializeField] int levelNo = 0;
    [SerializeField] GameObject gameCompleteCanvas;
    GameObject currentLevel = null;

    [Header("Win Detection")]
    [SerializeField] List<AttachBox> attachBoxesList = new List<AttachBox>();
    int attachBoxCount = 0;
    int verifyCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        gameCompleteCanvas.SetActive(false);
        levelSpawn();
    }

    void boxCount()
    {
        attachBoxesList.Clear();
        attachBoxesList.AddRange(GameObject.FindObjectsOfType<AttachBox>());
        attachBoxCount = attachBoxesList.Count;
    }

    public void CompleteVerification()
    {
        verifyCount = 0;
        boxCount();
        for (int i = 0; i < attachBoxesList.Count; i++)
        {
            if (attachBoxesList[i].IsAttached)
                verifyCount++;
        }
        if (verifyCount == attachBoxCount)
        {
            Invoke(nameof(NextLevel), 0.5f);
        }
    }

    void levelSpawn()
    {
        currentLevel = Instantiate(levels[levelNo]);
    }

    public void LoadLevel()
    {
        Destroy(currentLevel.gameObject);
        currentLevel = null;
        levelSpawn();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        levelNo++;
        if (levelNo == levels.Count)
        {
            gameCompleteCanvas.SetActive(true);
        }
        else
        {
            LoadLevel();
        }
    }
}
