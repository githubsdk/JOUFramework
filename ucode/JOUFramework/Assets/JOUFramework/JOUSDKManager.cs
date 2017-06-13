using UnityEngine;

namespace lee.foozuu.utils
{
    public class JOUSDKManager : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            InitSDK();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitSDK()
        {
            string receiver_name = "com.foozuu.utils.jousdkmgr";
#if UNITY_ANDROID || true
            try
            {
                AndroidJavaObject android_object = (AndroidJavaObject)GetObject("com.foozuu.ju.InitJUEntry");
                string result = android_object.CallStatic<string>(receiver_name);
                ShowLog(result);
            }
            catch(System.Exception e)
            {
                ShowLog(e.Message, true);
            }
#elif UNITY_IPHONE || UNITY_IOS

#endif
        }

        static public object CallStaticFunc(object classNameOrObj, object funcName, object valueType, params object[] args)
        {
#if UNITY_ANDROID || true
            try
            {

            }
            catch (System.Exception e)
            {
                ShowLog(e.Message, true);
            }
#elif UNITY_IPHONE || UNITY_IOS

#endif
            return null;
        }

        static public object GetObject(object classNameOrObj, params object[] args)
        {
#if UNITY_ANDROID || true
            try
            {
                AndroidJavaObject android_object = null;
                if (classNameOrObj.GetType() == typeof(string))
                {
                    if (args == null || args.Length == 0)
                    {
                        android_object = new AndroidJavaObject(classNameOrObj.ToString());
                    }
                    else
                    {
                        android_object = new AndroidJavaObject(classNameOrObj.ToString(), args);
                    }
                }
                else if (classNameOrObj.GetType() == typeof(AndroidJavaObject))
                {

                }
                return android_object;
            }
            catch (System.Exception e)
            {
                ShowLog(e.Message, true);
            }
#elif UNITY_IPHONE || UNITY_IOS

#endif
            return null;
        }

        static public void ShowLog(string log, bool error = false)
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
            System.Diagnostics.StackFrame sf = st.GetFrame(0);
            string msg = string.Format("[jou-error] {0} {1}::{2} {3}", sf.GetFileName(), sf.GetMethod().ReflectedType.Name, sf.GetMethod().Name, log==null ?  string.Empty : log);
            if(error==true)
            {
                Debug.LogError(msg);
            }
            else
            {
                Debug.Log(msg);
            }
        }

        void OnJOUCommonMessage(string message)
        {
            ShowLog(message);
        }
    }

}