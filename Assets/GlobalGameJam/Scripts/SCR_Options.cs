using UnityEngine;
using UnityEngine.UI;

public class SCR_Options : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] TMPro.TMP_Text sensitivityText;

    [Header("Mouse Variables")]
    public static float m_mouseSensitivity;

    private void Update()
    {
        m_mouseSensitivity = sensitivitySlider.value;
        sensitivityText.text = m_mouseSensitivity.ToString();
    }
}
