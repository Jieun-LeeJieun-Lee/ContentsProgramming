using UnityEngine;

public class ThermometerController : MonoBehaviour
{
    [Range(0f, 50f)]
    public float temperature = 25f;  // 온도
    public float maxHeight = 3f;     // 최대 높이

    public GameObject thermometerBar; // 큐브 연결용
    public GameObject ground;         // 바닥 연결용

    private Renderer barRenderer;
    private Renderer groundRenderer;

    void Start()
    {
        // Renderer 가져오기
        barRenderer = thermometerBar.GetComponent<Renderer>();
        groundRenderer = ground.GetComponent<Renderer>();
    }

    void Update()
    {
        UpdateThermometer();
    }

    void UpdateThermometer()
    {
        //-----------------------------
        // 1️⃣ 높이 제어
        //-----------------------------
        float normalizedTemp = Mathf.Clamp01(temperature / 50f); // 0~1 사이 비율
        float newHeight = Mathf.Max(0.1f, normalizedTemp * maxHeight);

        // 큐브의 크기(localScale) 변경
        thermometerBar.transform.localScale = new Vector3(1f, newHeight, 1f);

        // 큐브가 위로 자라나도록 Y위치 조정 (바닥 기준으로 위로)
        thermometerBar.transform.position = new Vector3(0, newHeight / 2f, 0);

        //-----------------------------
        // 2️⃣ 색상 제어 (ThermometerBar)
        //-----------------------------
        if (temperature < 15f)
        {
            barRenderer.material.color = Color.blue; // 파란색
        }
        else if (temperature < 30f)
        {
            barRenderer.material.color = Color.green; // 초록색
        }
        else
        {
            barRenderer.material.color = Color.red; // 빨간색
        }

        //-----------------------------
        // 3️⃣ Ground 색상 제어
        //-----------------------------
        if (temperature < 15f)
        {
            groundRenderer.material.color = Color.white; // 하얀색
        }
        else if (temperature < 30f)
        {
            groundRenderer.material.color = new Color(0.59f, 0.29f, 0.0f); // 갈색 (RGB 150,75,0)
        }
        else
        {
            groundRenderer.material.color = new Color(1f, 0.5f, 0f); // 주황색 (RGB 255,128,0)
        }
    }
}
