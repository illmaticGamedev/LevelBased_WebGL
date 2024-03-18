using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxLeapManager : MonoBehaviour
{
    public static BoxLeapManager Instance;

    [Header("Level Spawn")]
    [SerializeField] List<GameObject> levels;
    [SerializeField] int levelNo = 0;
    [SerializeField] GameObject gameCompleteCanvas;
    GameObject currentLevel = null;

    [Header("Player Management")]
    [SerializeField] GameObject playerGameObject;
    [SerializeField] Transform playerSpawnPoint;
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
        ResetPlayerPos();
    }

    public void NextLevel()
    {
        levelNo++;
        if(levelNo == levels.Count)
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

    public void ResetPlayerPos()
    {
        playerGameObject.transform.position = playerSpawnPoint.position;
        playerGameObject.GetComponent<BoxPlayer>().ResetPlayer();
    }
}
