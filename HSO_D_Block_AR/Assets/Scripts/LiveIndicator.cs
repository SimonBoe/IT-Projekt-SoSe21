using UnityEngine;
using UnityEngine.UI;

public class LiveIndicator : MonoBehaviour
{
    private Image image;
    private Color color;
    [HideInInspector]
    private float time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
