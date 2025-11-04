using UnityEngine;
using System.IO;     // File 클래스
using System.Text;   // Encoding 클래스

public class CSVReader : MonoBehaviour
{
    void Start()
    {
        // 1. CSV 파일 경로
        string csvPath = Path.Combine(
            Application.streamingAssetsPath,
            "ta_20251104093925.csv"
        );

        // 2. 파일 존재 확인
        if (File.Exists(csvPath))
        {
            // 3. 여러 인코딩 시도
            string content = null;

            // 먼저 EUC-KR (CP949) 시도 - 기상청 CSV는 보통 이 인코딩
            try
            {
                Encoding euckr = Encoding.GetEncoding("euc-kr");
                content = File.ReadAllText(csvPath, euckr);
                Debug.Log("✅ EUC-KR 인코딩으로 읽기 성공");
            }
            catch
            {
                // EUC-KR 실패 시 UTF-8 시도
                try
                {
                    content = File.ReadAllText(csvPath, Encoding.UTF8);
                    Debug.Log("✅ UTF-8 인코딩으로 읽기 성공");
                }
                catch
                {
                    Debug.LogError("❌ 파일 읽기 실패");
                    return;
                }
            }

            // 4. Console에 출력
            Debug.Log("===== CSV 파일 내용 =====");
            Debug.Log(content);

            // 5. Split 맛보기 (선택)
            string[] lines = content.Split('\n');
            Debug.Log("총 줄 수: " + lines.Length);
        }
        else
        {
            Debug.LogError("❌ CSV 파일을 찾을 수 없습니다: " + csvPath);
        }
    }
}