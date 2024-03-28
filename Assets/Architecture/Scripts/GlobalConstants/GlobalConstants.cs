using System.Collections;
using UnityEngine;

public static class GlobalConstants
{
    #region GAME TAGS
    public const string TAG_GROUND = "Ground";
    public const string TAG_OBSTACLE = "Obstacle";
    public const string TAG_ENDPT = "EndPoint";
    public const string TAG_GRAVITYPLATFORM = "GravityReverse";
    #endregion

    #region Animations
    public const string ANIM_CLICK = "isClicked";
    public const string ANIM_ISROTATING = "isRotating";
    public const string ANIM_FADE = "isFading";
    public const string ANIM_BOXATTACH = "attachBox";
    public const string ANIM_SPEED = "speed";
    public const string ANIM_DEAD = "isDead";
    public const string ANIM_WON = "hasWon";
    public const string ANIM_JUMP = "isJumping";
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
