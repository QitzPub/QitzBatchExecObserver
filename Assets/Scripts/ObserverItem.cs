using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using SFB;

public class ObserverItem : MonoBehaviour
{
    [SerializeField]
    InputField folderInput;
    [SerializeField]
    InputField batchInput;
    public string FolderPath => folderInput.text;
    public string BatchPath => batchInput.text;
    string requestFileNameInput;
    string TargetFilePath => FolderPath + "/" + requestFileNameInput;

    public SettingVO SettingVO = new SettingVO();

    public void Initialize(string requestFileNameInput, SettingVO settingVO)
    {
        this.requestFileNameInput = requestFileNameInput;
        batchInput.text = settingVO.BatchPath;
        folderInput.text = settingVO.FolderPath;
        this.SettingVO = settingVO;
    }

    public void Initialize(string requestFileNameInput)
    {
        this.requestFileNameInput = requestFileNameInput;
    }
    public void Dispose()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        InvokeRepeating("Exec", 1.0f, 3.0f);
    }

    public void SetBatchPath()
    {
        string[] outputPath = StandaloneFileBrowser.OpenFilePanel("batかshを選択", "", "sh",false);
        batchInput.text = outputPath[0];
        this.SettingVO.BatchPath = outputPath[0];
    }
    public void SetFolderPath()
    {
        string[] outputPath = StandaloneFileBrowser.OpenFolderPanel("監視対象フォルダを選択", "", false);
        //var path = EditorUtility.OpenFolderPanel("監視対象フォルダを選択　", "", "");
        folderInput.text = outputPath[0];
        this.SettingVO.FolderPath = outputPath[0];
    }

    void Exec()
    {
        if (File.Exists(TargetFilePath))
        {
            Debug.Log("ファイルの存在を確認：指定処理を実行します。");
            ExecBatch(this.BatchPath);
            File.Delete(TargetFilePath);
        }
    }
    void ExecBatch(string batchPath)
    {
        //実行したいshell script のフルパス
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.FileName = batchPath;
        p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //p.StartInfo.CreateNoWindow = false;   //ここを有効にするとcmdのウィンドウが非表示のまま実行される
        p.StartInfo.UseShellExecute = true;
        p.Start();
        //結果待ち
        p.WaitForExit();
        //string output = p.StandardOutput.ReadToEnd();
        p.Close();
    }
}
