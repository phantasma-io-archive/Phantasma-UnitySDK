using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PhantasmaLinkClientPluginManager : MonoBehaviour
{
    public static PhantasmaLinkClientPluginManager Instance { get; private set; }
    [SerializeField] private const string PluginName = "com.phantasma.phantasmalinkclient.PhantasmaLinkClientClass";
    
    private AndroidJavaClass UnityClass;
    private AndroidJavaObject UnityActivity;
    private AndroidJavaObject _PluginInstance;
    [SerializeField] private TMP_Text DebugOutput;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
#if UNITY_ANDROID || UNITY_EDITOR
        InitializePlugin(PluginName);
#endif
    }

    private void InitializePlugin(string pluginName)
    {
        UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        UnityActivity = UnityClass.GetStatic<AndroidJavaObject>("currentActivity");
        _PluginInstance = new AndroidJavaObject(pluginName);
        if (_PluginInstance == null)
        {
            Debug.LogError("Error Loading Plugin..");
        }
        
        _PluginInstance.CallStatic("ReceiveActivity", UnityActivity);
        PhantasmaLinkClient.Instance.Enable();
    }

    public void OnDoSomething()
    {
        var result = _PluginInstance.Call<string>("DoSomething");
        if (DebugOutput != null )
            DebugOutput.text = $"Something: {result}";
    }

    public void OpenWallet() => _PluginInstance.Call("OpenWallet");

    public async Task SendTransaction(string tx)
    {
        var result = _PluginInstance.Call<string>("SendMyCommand", tx);
        await Task.Delay(0);
    }

    public void Example()
    {
        PhantasmaLinkClient.Instance.Login();
    }

    public void HandleResult()
    {
        
    }
}
