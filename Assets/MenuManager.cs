using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Object = System.Object;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private bool _isPause = false;

    private Transform _return;
    private Transform _restart;

    // Start is called before the first frame update
    void Start()
    {
        _return = menu.transform.GetChild(0);
        _restart = menu.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPause = !_isPause;
        }
        Time.timeScale = _isPause ? 0 : 1;
        menu.SetActive(_isPause);
    }

    public void OnClickReturn()
    {
        _isPause = false;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}