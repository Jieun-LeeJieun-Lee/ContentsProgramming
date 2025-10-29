using UnityEngine;
using TMPro;   // TextMeshPro 사용을 위해 필요
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public GameObject lightBulb;     // 구 (Sphere)
    public TextMeshProUGUI statusText; // 상태 표시 텍스트
    public GameObject infoPanel;       // 추가 정보 패널

    private Renderer bulbRenderer;

    void Start()
    {
        bulbRenderer = lightBulb.GetComponent<Renderer>();
        SetDark(); // 초기 상태: 어두움
    }

    public void SetDark()
    {
        bulbRenderer.material.color = Color.gray;
        statusText.text = "밝기: 어두움";
        infoPanel.SetActive(false);
    }

    public void SetBright()
    {
        bulbRenderer.material.color = Color.white;
        statusText.text = "밝기: 밝음";
        infoPanel.SetActive(true);
    }
}
