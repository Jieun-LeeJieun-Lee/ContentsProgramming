using UnityEngine;

public class WeatherData : MonoBehaviour
{
    
    public float temperature;  // 온도
    public float humidity;     // 습도
    public string cityName;    // 도시 이름

    void Start()
    {
       
        cityName = "서울";
        temperature = 25.5f;
        humidity = 60f;

        // 체감온도 계산 
        float feelTemperature = temperature - (humidity / 100f * 2f);

        // 콘솔 출력 (출력 형식 반드시 동일해야 함)
        Debug.Log(cityName + "의 온도: " + temperature);
        Debug.Log("습도: " + humidity);
        Debug.Log("체감온도: " + feelTemperature);
    }
}
