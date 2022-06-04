using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LobbyUIManager : MonoBehaviour
{
    public static LobbyUIManager Instance;

    [SerializeField]
    private CustomizeUI customizeUI;

    public CustomizeUI CustomizeUI { get { return customizeUI; } }

    [SerializeField]
    private Button useButton;
    [SerializeField]
    private Sprite originUserButtonSprite;

    private void Awake()
    {
        Instance = this;
    }

    public void SetUseButton(Sprite sprite, UnityAction action)
    {
        useButton.image.sprite = sprite;
        useButton.onClick.AddListener(action);
        useButton.interactable = true;
    }

    public void UnsetUseButton()
    {
        useButton.image.sprite = originUserButtonSprite;
        useButton.onClick.RemoveAllListeners();
        useButton.interactable = false;
    }
}
