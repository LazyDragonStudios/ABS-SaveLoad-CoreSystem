using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ABS_SaveLoadSystem;
using System;
using System.Threading.Tasks;


[System.Serializable]
public class DragonCarePlayerData : PlayerData
{
    // Properties with private setters
    public int GoldCoins { get; private set; }
    public int ProductivityPoints { get; private set; }
    public int ProductivityMultiplier { get; private set; }
    public DateTime ProductivityBonusExpiry { get; private set; }
    public int EggPrice { get; private set; }
    public int AccesoryPrice { get; private set; }
    public DateTime LastJournalEntry { get; private set; }
    public int JournalingStreak { get; private set; }
    public AutoSaveList<DragonData> UnlockedDragons { get; private set; }
    public AutoSaveList<ToDoListItem> ToDoListItems { get; private set; }
    public AutoSaveList<AccesoryData> UnlockedAccessories { get; private set; }
    public AutoSaveList<JournalEnty> Journal { get; private set; }

    // Asynchronous factory method to load data
    public static async Task<DragonCarePlayerData> LoadAsync()
    {
        var data = new DragonCarePlayerData();

        // Load all properties
        data.GoldCoins = await data.LoadData<int>(nameof(GoldCoins));
        data.ProductivityPoints = await data.LoadData<int>(nameof(ProductivityPoints));
        data.ProductivityMultiplier = await data.LoadData<int>(nameof(ProductivityMultiplier), 1);
        data.ProductivityBonusExpiry = await data.LoadData<DateTime>(nameof(ProductivityBonusExpiry), DateTime.MinValue);
        data.EggPrice = await data.LoadData<int>(nameof(EggPrice), 100);
        data.AccesoryPrice = await data.LoadData<int>(nameof(AccesoryPrice), 100);
        data.LastJournalEntry = await data.LoadData<DateTime>(nameof(LastJournalEntry), DateTime.MinValue);
        data.JournalingStreak = await data.LoadData<int>(nameof(JournalingStreak));

        // Initialize and load AutoSaveList properties
        data.UnlockedDragons = await data.LoadOrCreateAutoSaveList<DragonData>(nameof(UnlockedDragons));
        data.ToDoListItems = await data.LoadOrCreateAutoSaveList<ToDoListItem>(nameof(ToDoListItems));
        data.UnlockedAccessories = await data.LoadOrCreateAutoSaveList<AccesoryData>(nameof(UnlockedAccessories));
        data.Journal = await data.LoadOrCreateAutoSaveList<JournalEnty>(nameof(Journal));

        return data;
    }


    // Example Specific Setter
    public async Task SetGoldCoinsAsync(int value)
    {
        await SetAsync(value, nameof(GoldCoins), v => GoldCoins = v);
    }

    public async Task SetProductivityPointsAsync(int value)
    {
        await SetAsync(value, nameof(ProductivityPoints), v => ProductivityPoints = v);
    }

    public async Task SetProductivityMultiplierAsync(int value)
    {
        await SetAsync(value, nameof(ProductivityMultiplier), v => ProductivityMultiplier = v);
    }

    public async Task SetProductivityBonusExpiryAsync(DateTime value)
    {
        await SetAsync(value, nameof(ProductivityBonusExpiry), v => ProductivityBonusExpiry = v);
    }

    public async Task SetEggPriceAsync(int value)
    {
        await SetAsync(value, nameof(EggPrice), v => EggPrice = v);
    }

    public async Task SetAccesoryPriceAsync(int value)
    {
        await SetAsync(value, nameof(AccesoryPrice), v => AccesoryPrice = v);
    }

    public async Task SetLastJournalEntryAsync(DateTime value)
    {
        await SetAsync(value, nameof(LastJournalEntry), v => LastJournalEntry = v);
    }

    public async Task SetJournalingStreakAsync(int value)
    {
        await SetAsync(value, nameof(JournalingStreak), v => JournalingStreak = v);
    }
}



[System.Serializable]
public class JournalEnty
{
    public DateTime Entry_Date { get; set; }
    public string Entry_Title { get; set; }
    public string Entry_Body { get; set;}
}
public class DragonData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int hatID { get; set; }
    public int backpackID { get; set; }
    public int holdingID { get; set; }
    public int petID { get; set; }
    public int rideableID { get; set; }
}

public class AccesoryData
{
    public int accesory_id;

    public int quantityOwned;
}


