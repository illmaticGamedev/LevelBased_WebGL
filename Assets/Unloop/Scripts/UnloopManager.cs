using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloopManager : MonoBehaviour
{
    public static UnloopManager Instance;

    [Header("Level Spawn")]
    [SerializeField] List<GameObject> levels;
    [SerializeField] int levelNo = 0;
    GameObject currentLevel = null;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void levelSpawn()
    {
        currentLevel = Instantiate(levels[levelNo]);
    }
}
