using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyEnter : MonoBehaviour {

    public KeyCode key;
    public string contB;
    Button b;

    // Use this for initialization
    void Start () {
        b = GetComponent<Button>();
    }

    void Update() {
        if(Input.GetKeyDown(key) || Input.GetButtonDown(contB))
        {
            b.onClick.Invoke();
        }
    }
}