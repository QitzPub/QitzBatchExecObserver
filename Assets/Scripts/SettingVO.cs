using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SettingParentVO
{
    public List<SettingVO> SettingVOs;
    public string targetFileName;
}


[Serializable]
public class SettingVO
{
    public string FolderPath;
    public string BatchPath;
}

