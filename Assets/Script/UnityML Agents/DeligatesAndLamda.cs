using UnityEngine;
using UnityEngine.UI;

public class DeligatesAndLamda : MonoBehaviour
{
    [SerializeField] private Button _clickMe;
    public string msg = "Button Clicked!!!";
    ExampleUsage exampleUsage;
    private void Start()
    {
        exampleUsage = GetComponent<ExampleUsage>();
        _clickMe.onClick.AddListener(() => exampleUsage.HandleButtonClick());
    }

}
