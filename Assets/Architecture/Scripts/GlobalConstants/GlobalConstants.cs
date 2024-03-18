using System.Collections;
using UnityEngine;

public static class GlobalConstants
{
    #region GAME TAGS
    public const string TAG_GROUND = "Ground";
    public const string TAG_OBSTACLE = "Obstacle";
    public const string TAG_ENDPT = "EndPoint";
    #endregion

    #region Animations
    public const string ANIM_CLICK = "isClicked";
    #endregion

    #region PlayerPrefs
    public const string PREF_LASTREACHEDLEVEL = "LEVELREACHED";
    public const string PREF_CURRENTLEVEL = "CURRENTLEVEL";
    #endregion

    #region Level Name
    public const string LEVEL_HEXAMATH = "Hexamath";
    public const string LEVEL_MENU = "Menu";
    #endregion
}
