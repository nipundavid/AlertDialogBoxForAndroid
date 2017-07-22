using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    // To display output of the alert box
    public Text reply;
 
    // To store context of the main activity that Unity3D is running
    private AndroidJavaObject activityContext = null;

    // To store the instance of the class
    private AndroidJavaObject nativeDialogBox = null;

    void Start()
    {
        AndroidCallBacks androidCallbacks = new GameObject("AndroidCallBacks").AddComponent<AndroidCallBacks>();

        // Get MainActivity class instance that Unity is running
        using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            // Get context of the MainActivity class that unity is running
            activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }

    public void ShowNativeDialogBox()
    {
        CallNativeDialogBox("Dialog Box", "This is a Dialog box", "Yes", "No");
    }

    private void CallNativeDialogBox(params object[] args)
    {
        AndroidJavaObject bridge = new AndroidJavaObject("com.plugin.android.dialogboxmodule.ShowNativeDialogBox");

        activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            bridge.CallStatic("ShowDialogPopup", args);
        }));
    }
}