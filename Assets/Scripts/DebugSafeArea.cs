using UnityEngine;
using UnityEngine.UI;

public class DebugSafeArea : MonoBehaviour
{
    public Toggle toggle;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(toggle.isOn ? OHSafeArea.safeArea : Screen.safeArea);
    }
}
