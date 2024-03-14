using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] MainMenu menu;
    public static int CurrLevel = 0;
    int completedLevels = 0;
    [SerializeField] Transform buttonsParent;
    [SerializeField] List<Button> levelButtons;

    private void Start()
    {
        defaultValueLoading();
        completedLevelCheck();
        buttonAddInList();
        buttonActivator();
    }

    #region Initialization
    void defaultValueLoading()
    {
        if (!PlayerPrefs.HasKey(GlobalConstants.PREF_LASTREACHEDLEVEL))
        {
            PlayerPrefs.SetInt(GlobalConstants.PREF_LASTREACHEDLEVEL, 0);
        }
    }

    void completedLevelCheck()
    {
        completedLevels = PlayerPrefs.GetInt(GlobalConstants.PREF_LASTREACHEDLEVEL);
    }
    #endregion

    #region Button Addition and Activation
    void buttonAddInList()
    {
        for (int i = 0; i < buttonsParent.childCount; i++)
        {
            levelButtons.Add(buttonsParent.GetChild(i).GetComponent<Button>());
        }
    }

    void buttonActivator()
    {
        foreach(Button i in levelButtons)
        {
            i.interactable = false;
        }

        for(int i=0;i<=completedLevels;i++)
        {
            if (levelButtons[i] != null)
            levelButtons[i].interactable = true;
        }
    }
    #endregion

    #region Button Actions
    public void IsCompleteButton()
    {
        if(CurrLevel == completedLevels)
        {
            completedLevels++;
            PlayerPrefs.SetInt(GlobalConstants.PREF_LASTREACHEDLEVEL, completedLevels);
        }
        SoundManager.Instance.CompleteSound();
        buttonActivator();
        menu.BackToMenu();
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt(GlobalConstants.PREF_LASTREACHEDLEVEL, 0);
    }
    #endregion
}
