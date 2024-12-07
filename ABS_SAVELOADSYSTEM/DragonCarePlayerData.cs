using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ABS_SaveLoadSystem;
using System;


[System.Serializable]
public class DragonCarePlayerData : PlayerData
{
    // Currencies
    public int GoldCoins
    {
        get => LoadData<int>(nameof(GoldCoins)).GetAwaiter().GetResult();
        set => SaveData(value, nameof(GoldCoins));
    }
    public int ProductivityPoints
    {
        get => LoadData<int>(nameof(ProductivityPoints)).GetAwaiter().GetResult();
        set => SaveData(value, nameof(ProductivityPoints));
    }
    public int ProductivityMultiplier
    {
        get => LoadData<int>(nameof(ProductivityMultiplier),1).GetAwaiter().GetResult();
        set => SaveData(value, nameof(ProductivityMultiplier));
    }
    public DateTime ProductivityBonusExpiry
    {
        get => LoadData<DateTime>(nameof(ProductivityBonusExpiry), DateTime.MinValue).GetAwaiter().GetResult();
        set => SaveData(value, nameof(ProductivityBonusExpiry));
    }

    // Currency settings
    public int EggPrice
    {
        get => LoadData<int>(nameof(EggPrice),100).GetAwaiter().GetResult();
        set => SaveData(value, nameof(EggPrice));
    }

    public int AccesoryPrice
    {
        get => LoadData<int>(nameof(AccesoryPrice),100).GetAwaiter().GetResult();
        set => SaveData(value, nameof(AccesoryPrice));
    }

    // Journaling System
    public DateTime LastJournalEntry
    {
        get => LoadData<DateTime>(nameof(LastJournalEntry), DateTime.MinValue).GetAwaiter().GetResult();
        set => SaveData(value, nameof(LastJournalEntry));
    }

    public int JournalingStreak
    {
        get => LoadData<int>(nameof(JournalingStreak)).GetAwaiter().GetResult();
        set => SaveData(value, nameof(JournalingStreak));
    }

    // Dragon Collection
    // Using AutoSaveList for automatic saving when items are added or removed
    public AutoSaveList<DragonNPCScriptable> UnlockedDragons
    {
        get => LoadData<AutoSaveList<DragonNPCScriptable>>(nameof(UnlockedDragons), new AutoSaveList<DragonNPCScriptable>(nameof(UnlockedDragons))).GetAwaiter().GetResult();
        set => SaveData(value, nameof(UnlockedDragons));
    }

    public AutoSaveList<ToDoListItem> ToDoListItems
    {
        get => LoadData<AutoSaveList<ToDoListItem>>(nameof(ToDoListItems), new AutoSaveList<ToDoListItem>(nameof(ToDoListItems))).GetAwaiter().GetResult();
        set => SaveData(value, nameof(ToDoListItems));
    }
    public AutoSaveList<DragonAccesory> UnlockedAccessories
    {
        get => LoadData<AutoSaveList<DragonAccesory>>(nameof(UnlockedAccessories), new AutoSaveList<DragonAccesory>(nameof(UnlockedAccessories))).GetAwaiter().GetResult();
        set => SaveData(value, nameof(UnlockedAccessories));
    }
    public AutoSaveList<JournalEnty> Journal
    {
        get => LoadData<AutoSaveList<JournalEnty>>(nameof(Journal), new AutoSaveList<JournalEnty>(nameof(Journal))).GetAwaiter().GetResult();
        set => SaveData(value, nameof(Journal));
    }
}

[System.Serializable]
public class JournalEnty
{
    public DateTime Entry_Date { get; set; }
    public string Entry_Title { get; set; }
    public string Entry_Body { get; set;}
}
