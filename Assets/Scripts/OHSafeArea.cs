using UnityEngine;

public class OHSafeArea : MonoBehaviour
{

    public static Rect safeArea
    {
        get
        {
            if (_init) return _safeArea;
            Init();
            return _safeArea;
        }
    }
    private static bool _init;

    private static Rect _safeArea = Rect.zero;
    
    private static void Init()
    {
        _safeArea = Screen.safeArea;
        var openHarmonyJsObject = new OpenHarmonyJSObject("SafeArea");
        var callback =
            new OpenHarmonyJSCallback(args => { _safeArea = Screen.safeArea; });
        openHarmonyJsObject.Call("onAvoidAreaChange", callback);
        _init = true;
    }
}
