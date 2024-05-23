using UnityEngine;

public class OHSafeArea : MonoBehaviour
{
    private static OHSafeArea _ohSafeArea;
    public static Rect safeArea
    {
        get
        {
            if (_ohSafeArea) return _ohSafeArea._safeArea;
            var go = new GameObject("OHSafeArea");
            DontDestroyOnLoad(go);
            _ohSafeArea = go.AddComponent<OHSafeArea>();
            _ohSafeArea._safeArea = Screen.safeArea;
            return _ohSafeArea._safeArea;
        }
    }

    Rect _safeArea = Rect.zero;
    
    void Awake()
    {
        var openHarmonyJsObject = new OpenHarmonyJSObject("SafeArea");
        var callback =
            new OpenHarmonyJSCallback(args => { _safeArea = Screen.safeArea; });
        openHarmonyJsObject.Call("onAvoidAreaChange", callback);
    }
}
