using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    private Text text;

    private void Start() {
        text = GetComponent<Text>();
    }

    public void ResetText() {
        text.text = "Click on a room to see more info";
    }
}
