using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Button MouseControllButton;
    [SerializeField]
    private Button KeyboardMouseControllButton;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MouseControllButton.image.color = Color.green;
                KeyboardMouseControllButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                MouseControllButton.image.color = Color.white;
                KeyboardMouseControllButton.image.color = Color.green;
                break;
        }
    }

    public void SetControllMode(int controlType)
    {
        PlayerSettings.controlType = (EControlType)controlType;
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MouseControllButton.image.color = Color.green;
                KeyboardMouseControllButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                MouseControllButton.image.color = Color.white;
                KeyboardMouseControllButton.image.color = Color.green;
                break;
        }
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
