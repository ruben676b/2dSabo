using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DeadUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private UIDocument menu;
    private Button restart;
    private void Start()
    {
        UI.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;

        restart = root.Q<Button>("restart");

        restart.RegisterCallback<ClickEvent>(ReloadScene);
    }

    void ReloadScene(ClickEvent evt)
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);

        UI.gameObject.SetActive(false);
    }
}
