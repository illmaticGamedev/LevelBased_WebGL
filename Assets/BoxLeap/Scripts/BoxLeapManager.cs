using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxLeapManager : MonoBehaviour
{
    public static BoxLeapManager Instance;

    [Header("Level Spawn")]
    [SerializeField] List<GameObject> levels;
    [SerializeField] int levelNo = 0;
    [SerializeField] GameObject gameCompleteCanvas;
    [SerializeField] TMP_Text deathInfoText;
    GameObject currentLevel = null;

    [Header("Player Management")]
    [SerializeField] GameObject playerGameObject;
    [SerializeField] Transform playerSpawnPoint;

    [Header("Death Counter")]
    int deaths = 0;
    [SerializeField] TMP_Text deathCounterText;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameCompleteCanvas.SetActive(false);
        deathCounterText.text = "0";
        levelSpawn();
    }

    void levelSpawn()
    {
        currentLevel = Instantiate(levels[levelNo]);
        ResetPlayerPos();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        levelNo++;
        if(levelNo == levels.Count)
        {
            deathInfoText.text = "You have completed the game with " + deaths + " Deaths. Can you do better?";
            gameCompleteCanvas.SetActive(true);
        }
        else
        {
            Destroy(currentLevel.gameObject);
            currentLevel = null;
            levelSpawn();
        }
    }

    public void DeathTrigger()
    {
        deaths++;
        deathCounterText.text = deaths.ToString();
    }

    public void ResetPlayerPos()
    {
        playerGameObject.transform.position = playerSpawnPoint.position;
        playerGameObject.GetComponent<BoxPlayer>().ResetPlayer();
    }
}
