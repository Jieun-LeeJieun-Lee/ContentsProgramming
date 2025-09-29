using UnityEngine;

public class TemperatureColor : MonoBehaviour
{
    public float temperature = 20.0f;
    public Color coldColor = Color.blue;
    public Color normalColor = Color.green;
    public Color hotColor = Color.red;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Renderer myRenderer;
    void Start()
    {
        // Renderer 컴포넌트 가져오기
        Renderer renderer = GetComponent<Renderer>();
        
        // 온도에 따라 색상 결정
       
        
        
    }
    void Update()
    {
        // 온도에 따라 색상 결정
        if (temperature < 15.0f)
        {
            GetComponent<Renderer>().material.color = coldColor;
            Debug.Log(temperature + "도: 차가워요! (파란색)");
        }
        else if (temperature < 30.0f)
        {
            GetComponent<Renderer>().material.color = normalColor;
            Debug.Log(temperature + "도: 적당해요! (녹색)");
        }
        else
        {
            GetComponent<Renderer>().material.color =hotColor;
            Debug.Log(temperature + "도: 뜨거워요! (빨간색)");
        }
    }


}
