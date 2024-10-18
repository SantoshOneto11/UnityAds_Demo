using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExampleUsage : MonoBehaviour
{
    private DeligatesAndLamda _script;
    [SerializeField] private TMP_InputField _inputField;
    private void Start()
    {
        _script = GetComponent<DeligatesAndLamda>();

        // Subscribe to the ButtonAction event
        //_script.buttonClicked += HandleButtonClick;

        // Unsubscribe from the ButtonAction event
        //_script.buttonClicked -= HandleButtonClick;
    }

    public void HandleButtonClick()
    {
        _inputField.text = _script.msg;
        Debug.Log("Button Clicked!");
    }
}
