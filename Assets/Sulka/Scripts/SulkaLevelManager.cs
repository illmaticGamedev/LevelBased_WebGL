using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SulkaLevelManager : MonoBehaviour
{
    public static SulkaLevelManager Instance;

    [Header("Level Spawn")]
    [SerializeField] List<GameObject> levels;
    [SerializeField] int levelNo = 0;
    [SerializeField] GameObject gameCompleteCanvas;
    GameObject currentLevel = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameCompleteCanvas.SetActive(false);
        levelSpawn();
    }

    void levelSpawn()
    {
        currentLevel = Instantiate(levels[levelNo]);
    }

    public void RestartScene()
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
            Destroy(currentLevel.gameObject);
            currentLevel = null;
            levelSpawn();
        }
    }
    public void LoadLevel()
    {
        Destroy(currentLevel.gameObject);
        currentLevel = null;
        levelSpawn();
    }
}
