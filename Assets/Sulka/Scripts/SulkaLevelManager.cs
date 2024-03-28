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
    [SerializeField] GameObject deathParticleSystem;

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

    public GameObject ParticleSystemSpawn()
    {
        GameObject ps = Instantiate(deathParticleSystem, currentLevel.transform);
        return ps;
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
