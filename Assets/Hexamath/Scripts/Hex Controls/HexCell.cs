using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexCell : MonoBehaviour
{
    HexManager hexMan;
    public int Value = 0;
    Image valueImage;
    Animator anim;

    void Start()
    {
        hexMan = HexManager.Instance;
        anim = GetComponent<Animator>();
        valueImage = transform.GetChild(0).GetComponent<Image>();
    }

    public void ChangeValue()
    {
        if(!hexMan.IsComplete)
        {
        SoundManager.Instance.TapSound();
        anim.SetBool(GlobalConstants.ANIM_CLICK, false);
        anim.SetBool(GlobalConstants.ANIM_CLICK, true);
        Value++;
        if(Value > 3)
        {
            Value = 0;
        }
        UpdateColor();
        hexMan.HexSumChecker();
        }
    }

    private void UpdateColor()
    {
        switch (Value)
        {
            case 0:
                valueImage.sprite = hexMan.ZeroSprite; break;
            case 1:
                valueImage.sprite = hexMan.OneSprite; break;
            case 2:
                valueImage.sprite = hexMan.TwoSprite; break;
            case 3:
                valueImage.sprite = hexMan.ThreeSprite; break;
            default:
                valueImage.sprite = hexMan.ZeroSprite; break;
        };
    }

    public void GreenColorChange()
    {
        GetComponent<Image>().color= Color.green;
    }

    public void WhiteColorChange()
    {
        GetComponent<Image>().color = Color.white;
    }

    public void ClickAnimationFalse()
    {
        anim.SetBool(GlobalConstants.ANIM_CLICK, false);
    }
}

