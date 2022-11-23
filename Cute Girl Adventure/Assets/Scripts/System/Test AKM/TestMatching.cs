using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatching : MonoBehaviour
{
    int[] soal, jawaban;
    bool firstClick;
    public void Soal(int indexSoal, int valueSoal)
    {
        soal[indexSoal] = valueSoal;
        firstClick = true;
    }

    public void Jawaban(int indexJawaban, int valueJawaban)
    {
        if(!firstClick)
        {
            print("Pilih sebelah kiri");
            return;
        }
        else
        {
            jawaban[indexJawaban] = valueJawaban;
        }    
    }

    private void FixedUpdate()
    {
        if(soal == jawaban)
        {

        }
    }
}
