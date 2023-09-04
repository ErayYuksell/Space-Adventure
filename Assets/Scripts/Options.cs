using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Options // Kayit sistemi heryerden erisilebilir olmasi icin static hale getiriyoruz
{
    public static string easy = "easy"; //cagirdigim class icinde static oldugu icin degerini degistiremem direkt olarak burda degerinni vermem lazim 
    public static string medium = "medium";
    public static string hard = "hard";
    public static string easyScore = "easy";
    public static string mediumScore = "medium";
    public static string hardScore = "hard";
    public static string easyGold = "easy";
    public static string mediumGold = "medium";
    public static string hardGold = "hard";
    public static string muzikOpen = "muzikOpen";
    // asagidaki kodlarin hepsi  true ve false a gore 1 ve 0 olmasi uzerine islem yapiyor 
    public static void EasySetValue(int easy)//normalde playerPrefbs bool tutmayi destekleseydi onu kullanirdik ama desteklemiyor 
    {
        PlayerPrefs.SetInt(Options.easy, easy);
    }
    public static int EasyGetValue()
    {
        return PlayerPrefs.GetInt(Options.easy);
    }
    public static void MediumSetValue(int medium)
    {
        PlayerPrefs.SetInt(Options.medium, medium);
    }
    public static int MediumGetValue()
    {
        return PlayerPrefs.GetInt(Options.medium);
    }
    public static void HardSetValue(int hard)
    {
        PlayerPrefs.SetInt(Options.hard, hard);
    }
    public static int HardGetValue()
    {
        return PlayerPrefs.GetInt(Options.hard);
    }
    public static void EasyScoreSetValue(int easyScore)//normalde playerPrefbs bool tutmayi destekleseydi onu kullanirdik ama desteklemiyor 
    {
        PlayerPrefs.SetInt(Options.easyScore, easyScore);
    }
    public static int EasyScoreGetValue()
    {
        return PlayerPrefs.GetInt(Options.easyScore);
    }
    public static void MediumScoreSetValue(int mediumScore)
    {
        PlayerPrefs.SetInt(Options.mediumScore, mediumScore);
    }
    public static int MediumScoreGetValue()
    {
        return PlayerPrefs.GetInt(Options.mediumScore);
    }
    public static void HardScoreSetValue(int hardScore)
    {
        PlayerPrefs.SetInt(Options.hardScore, hardScore);
    }
    public static int HardScoreGetValue()
    {
        return PlayerPrefs.GetInt(Options.hardScore);
    }
    public static void EasyGoldSetValue(int easyGold)
    {
        PlayerPrefs.SetInt(Options.easyGold, easyGold);
    }
    public static int EasyGoldGetValue()
    {
        return PlayerPrefs.GetInt(Options.easyGold);
    }
    public static void MediumGoldSetValue(int mediumGold)
    {
        PlayerPrefs.SetInt(Options.mediumGold, mediumGold);
    }
    public static int MediumGoldGetValue()
    {
        return PlayerPrefs.GetInt(Options.mediumGold);
    }
    public static void HardGoldSetValue(int hardGold)
    {
        PlayerPrefs.SetInt(Options.hardGold, hardGold);
    }
    public static int HardGoldGetValue()
    {
        return PlayerPrefs.GetInt(Options.hardGold);
    }

    public static void MuzikOpenSetValue(int muzikOpen)
    {
        PlayerPrefs.SetInt(Options.muzikOpen, muzikOpen);
    }
    public static int MuzikOpenGetValue()
    {
        return PlayerPrefs.GetInt(Options.muzikOpen);
    }
    public static bool IsThereHaveRecord()
    {
        //if (/*PlayerPrefs.HasKey(Options.easy) || PlayerPrefs.HasKey(Options.medium) || PlayerPrefs.HasKey(Options.hard)*/)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        if (EasyGetValue() == 1 || MediumGetValue() == 1 || HardGetValue() == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool MuzikHaveRecord()
    {
        if (PlayerPrefs.HasKey(Options.muzikOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
