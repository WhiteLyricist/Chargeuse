using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCubeText;
    [SerializeField] private TextMeshProUGUI _scoreCapsuleText;
    [SerializeField] private TextMeshProUGUI _scoreSphereText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _panel;

    private int _scoreCube = 0;
    private int _scoreCapsule = 0;
    private int _scoreSphere = 0;

    private int _countCube = 0;
    private int _countCapsule = 0;
    private int _countSphere = 0;

    void Start()
    {
        TriggerController.Count += OnCount;
        ObjectGenerator.Generation += OnGeneration;
    }

    void OnCount(string nameItem) 
    {
        switch (nameItem)
        {
            case "Cube":
                _scoreCube++;
                _scoreCubeText.text = _scoreCube.ToString();
                _countCube--;
                break;

            case "Capsule":
                _scoreCapsule++;
                _scoreCapsuleText.text = _scoreCapsule.ToString();
                _countCapsule--;
                break;

            case "Sphere":
                _scoreSphere++;
                _scoreSphereText.text = _scoreSphere.ToString();
                _countSphere--;
                break;
        }

        if ((_countCapsule + _countCube + _countSphere) == 0) 
        {
            _panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            _scoreText.text = "Score: Cube = " + _scoreCube.ToString() + ", Capsule = " + _scoreCapsule.ToString() + ", Sphere = " + _scoreSphere.ToString();
        }
    }

    void OnGeneration(int count, string nameItem) 
    {
        switch (nameItem)
        {
            case "Cube":
                _countCube = count;
                break;

            case "Capsule":
                _countCapsule = count;
                break;

            case "Sphere":
                _countSphere = count;
                break;
        }
    }

    private void OnDestroy()
    {
        TriggerController.Count -= OnCount;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
