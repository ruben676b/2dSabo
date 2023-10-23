using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIControler : MonoBehaviour
{
    [SerializeField] UIDocument menu;

    Button play;
    Button setting;
    Button credit;
    private void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;

        play = root.Q<Button>("play");
        setting = root.Q<Button>("setting");
        credit = root.Q<Button>("credit");


        play.RegisterCallback<ClickEvent>(LoadNextScene);
    }
    void LoadNextScene(ClickEvent evt)
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
        Debug.Log("siguiente nivel");
    }
}