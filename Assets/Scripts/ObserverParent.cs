using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;

public class ObserverParent : MonoBehaviour
{
    [SerializeField]
    ObserverItem observerItemPrefab;
    List<ObserverItem> observerItems = new List<ObserverItem>();
    [SerializeField]
    Transform uiParent;
    [SerializeField]
    InputField requestFileNameInput;
    string SettingJsonPath => $"{Directory.GetCurrentDirectory()}/Setting.json";

    public void CreateObserverItem()
    {
        var item = PrefabFolder.InstantiateTo<ObserverItem>(observerItemPrefab, uiParent);
        item.Initialize(requestFileNameInput.text);
        observerItems.Add(item);
        //return item;
    }
    public ObserverItem CreateObserverItem(SettingVO settingVO, string requestFileNameInput)
    {
        var item = PrefabFolder.InstantiateTo<ObserverItem>(observerItemPrefab, uiParent);
        item.Initialize(requestFileNameInput, settingVO);
        observerItems.Add(item);
        return item;
    }

    public void OutPutSettingJson()
    {
        string json = "";
        var settings = observerItems.Select(oi => oi.SettingVO).ToList();
        var data = new SettingParentVO();
        data.SettingVOs = settings;
        data.targetFileName = requestFileNameInput.text;
        json = JsonUtility.ToJson(data);
        //Json取得処理いれる
        File.WriteAllText(this.SettingJsonPath,json);
        Debug.Log("設定データを書き出しました");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (System.IO.File.Exists(SettingJsonPath))
        {
            StreamReader sr = new StreamReader(SettingJsonPath, Encoding.GetEncoding("Shift_JIS"));
            string json = sr.ReadToEnd();
            sr.Close();
            SettingParentVO settingParentVO = JsonUtility.FromJson<SettingParentVO>(json);
            requestFileNameInput.text = settingParentVO.targetFileName;
            foreach (var svo in settingParentVO.SettingVOs)
            {
                var item = CreateObserverItem(svo,settingParentVO.targetFileName);
            }
        }
    }

}
