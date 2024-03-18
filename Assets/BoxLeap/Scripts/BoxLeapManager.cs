using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLeapManager : MonoBehaviour
{
    public static BoxLeapManager Instance;
    [SerializeField] List<GameObject> levels;
    [SerializeField] int levelNo = 0;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fetchLevel();
        levelSpawn();
    }

    void fetchLevel()
    {
        levelNo = 0;
    }

    void levelSpawn()
    {
        Instantiate(levels[levelNo]);
    }
}
