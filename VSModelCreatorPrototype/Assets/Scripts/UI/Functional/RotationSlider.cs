using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RotationSlider : MonoBehaviour
{
    public static bool UnlockAllAngles = false;
    public static UnityEvent UnlockAllAnglesChanged = new UnityEvent(); 

    public Slider rotSlider;

    private void Start()
    {
        UnlockAllAnglesChanged.AddListener(UnlockAllAnglesChangedCall);
    }

    public void SwapUnlockAllAngles(TMP_Text buttonText)
    {
        UnlockAllAngles = !UnlockAllAngles;
        UnlockAllAnglesChanged.Invoke();
        buttonText.text = UnlockAllAngles ? "Lock Angles" : "Unlock Angles";
    }

    void UnlockAllAnglesChangedCall()
    {
        if (UnlockAllAngles && rotSlider.minValue > -30)
        {
            rotSlider.minValue = -180;
            rotSlider.maxValue = 180;
            rotSlider.SetValueWithoutNotify(rotSlider.value * (180f / 8f));
        }
        else if (!UnlockAllAngles && rotSlider.minValue < -30)
        {
            rotSlider.SetValueWithoutNotify(rotSlider.value / (180f / 8f));
            rotSlider.minValue = -8;
            rotSlider.maxValue = 8;
        }
    }

    public void SetToRotationValue(float rot)
    {
        //Replace 8 with number of steps needed.
        float trueVal = UnlockAllAngles ? rot : rot / (180f / 8);
        rotSlider.SetValueWithoutNotify(trueVal);
    }

    public float Val
    {
        get
        {
            return UnlockAllAngles ? rotSlider.value : rotSlider.value * (180f / 8f);
        }
    }
}
