using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataSoal 
{
    public string status;
    public string message;
    public DetailSoal[] result;
}

[System.Serializable]

public class DetailSoal
{
    public int id;
    public string question;
    public int level_number;
    public DetailOpsi[] options;
}

[System.Serializable]

public class DetailOpsi
{
    public int id;
    public string description;
    public string correct_answer;
}
