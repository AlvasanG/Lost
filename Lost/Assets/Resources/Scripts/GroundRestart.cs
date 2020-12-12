using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundRestart : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
