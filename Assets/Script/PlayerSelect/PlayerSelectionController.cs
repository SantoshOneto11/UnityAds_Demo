using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectionController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Image playerImage;
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text speed;
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text power;

    private void Start()
    {
        SetSelectableData(playerData);
    }
    void SetSelectableData(PlayerData _playerData)
    {
        foreach (var data in _playerData.gameData)
        {
            playerImage.sprite = data.playerImage;
            playerName.text = data.playerName;
            speed.text = data.speed;
            health.text = data.health;
            power.text = data.power;
        }

    }
}
