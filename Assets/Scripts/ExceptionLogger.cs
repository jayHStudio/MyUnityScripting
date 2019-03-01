// JayH
// 사용자로부터 오류메세지를 로깅하여 파일에 저장한다.

using System.Collections;
using System.IO;
using UnityEngine;

namespace JayH
{

    public class ExceptionLogger : MonoBehaviour
    {
        // StreamWriter 오브젝트의 내부 참조변수
        private StreamWriter SW;

        // 로그를 남길 파일 이름
        public string logFileName = "log.txt";


        private void Start()
        {
            // 오브젝트가 파괴되지 않고 유지되도록 한다.
            DontDestroyOnLoad(this.gameObject);

            // 문자열 기록 오브젝트를 생성한다.
            SW = new StreamWriter(Application.persistentDataPath + "/" + logFileName);

            Debug.Log(Application.persistentDataPath + "/" + logFileName);
        }

        // 예외를 받아 기록할 수 있도록 등록한다.
        private void OnEnable()
        {
            Application.RegisterLogCallback(HandleLog);
        }

        // 예외 수신 등록을 해제한다.
        private void OnDisable()
        {
            Application.RegisterLogCallback(null);
        }

        // 예외를 텍스트 파일로 기록한다.
        private void HandleLog(string logString, string stackTrace, LogType type)
        {
            SW.WriteLine("Logged at: " + System.DateTime.Now.ToString()
                       + " - Log Desc: " + logString
                       + " - Trace: " + stackTrace
                       + " - Type: " + type.ToString()
            );
        }

        // 오브젝트가 파괴될 때 호출된다.
        private void OnDestroy()
        {
            SW.Close();
        }
    }

}