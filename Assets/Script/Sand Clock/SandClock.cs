using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SandClock : MonoBehaviour
{
    [SerializeField] Image fillTopImage;
    [SerializeField] Image fillBottomImage;
    [SerializeField] Image sandDotImage;
    [SerializeField] TMP_Text roundTxt;
    [SerializeField] RectTransform sandPyraminddRect;

    [HideInInspector] public UnityAction onAllRoundsComplete;
    [HideInInspector] public UnityAction<int> onRoundStart;
    [HideInInspector] public UnityAction<int> onRoundEnd;

    [Space(30f)]
    public float roundDuration = 10f;
    public int totalRounds = 3;

    float defaultSandPyramindPos;
    int currentRound = 0;

    private void Awake()
    {
        SetRoundTxt(totalRounds);
        defaultSandPyramindPos = sandPyraminddRect.anchoredPosition.y;
        sandDotImage.DOFade(0f, 0f);
    }

    public void Begin()
    {
        ++currentRound;
        if (onRoundStart != null)
            onRoundStart.Invoke(currentRound);

        sandDotImage.DOFade(1f, 0.8f);
        sandDotImage.material.DOOffset(Vector2.down * -roundDuration, roundDuration).From(Vector2.zero).SetEase(Ease.Linear);

        sandPyraminddRect.DOScaleY(1f, roundDuration / 3f).From(0f);
        sandPyraminddRect.DOScaleY(0f, roundDuration / 1.5f).SetDelay(roundDuration / 3f).SetEase(Ease.Linear);

        sandPyraminddRect.anchoredPosition = Vector2.up * defaultSandPyramindPos;
        sandPyraminddRect.DOAnchorPosY(0f, roundDuration).SetEase(Ease.Linear);

        ResetClock();

        roundTxt.DOFade(1f, 0.8f);

        fillTopImage
            .DOFillAmount(0, roundDuration)
            .SetEase(Ease.Linear)
            .OnUpdate(OnTimeUpdate)
            .OnComplete(OnRoundTimeComplete);
    }

    void OnTimeUpdate()
    {
        fillBottomImage.fillAmount = 1f - fillTopImage.fillAmount;
    }

    void OnRoundTimeComplete()
    {
        //round end event
        if (onRoundEnd != null)
            onRoundEnd.Invoke(currentRound);

        if (currentRound < totalRounds)
        {
            //there is more rounds
            roundTxt.DOFade(0f, 0f);
            transform
                .DORotate(Vector3.forward * 180f, 0.8f, RotateMode.FastBeyond360)
                .From(Vector3.zero)
                .SetEase(Ease.InOutBack)
                .OnComplete(() =>
                {
                    SetRoundTxt(totalRounds - currentRound);
                    Begin();
                });
        }
        else
        {
            //if finished all rounds


            //all rounds complete
            if (onAllRoundsComplete != null)
                onAllRoundsComplete.Invoke();

            SetRoundTxt(0);
            transform.DOShakeScale(0.8f, 0.3f, 10, 90f, true);
        }
    }

    void SetRoundTxt(int value)
    {
        roundTxt.text = value.ToString();
    }

    public void ResetClock()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        fillTopImage.fillAmount = 1f;
        fillBottomImage.fillAmount = 0f;
    }
}
