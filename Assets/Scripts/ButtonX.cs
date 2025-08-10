using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonX : MonoBehaviour
{
    public Button playButton;
    public Button restartButton;

    private GameControls controls;

    void Awake()
    {
        controls = new GameControls();
        controls.UI.Submit.performed += ctx => OnSubmit();
    }

    private void OnEnable()
    {
        controls.UI.Enable();
    }

    private void OnDisable()
    {
        controls.UI.Disable();
    }

    private void OnSubmit()
    {
        if (playButton != null && playButton.gameObject.activeInHierarchy)
        {
            playButton.onClick.Invoke();
        }
        else if (restartButton != null && restartButton.gameObject.activeInHierarchy)
        {
            restartButton.onClick.Invoke();
        }
    }
}
