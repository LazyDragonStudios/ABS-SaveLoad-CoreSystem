using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABS_SaveLoadSystem
{
    [System.Serializable]
    public class AutoSaveList<T> : List<T>
    {
        private readonly string propertyName;

        // Constructor takes the property name to use for saving
        public AutoSaveList(string propertyName)
        {
            this.propertyName = propertyName;
        }

        // Override Add method to automatically save after adding an item
        public new void Add(T item)
        {
            base.Add(item);
            // Call Save asynchronously
            SaveListAsync().ConfigureAwait(false);
        }

        // Override Remove method to automatically save after removing an item
        public new bool Remove(T item)
        {
            bool removed = base.Remove(item);
            if (removed)
            {
                // Call Save asynchronously
                SaveListAsync().ConfigureAwait(false);
            }
            return removed;
        }

        // Override Clear method to automatically save after clearing the list
        public new void Clear()
        {
            base.Clear();
            // Call Save asynchronously
            SaveListAsync().ConfigureAwait(false);
        }

        // Method to save the list using SaveData
        private async Task SaveListAsync()
        {
            if (PlayerManager.instance != null && PlayerManager.instance.saveLoadManager != null)
            {
                // Wait for the Save operation to complete (if necessary)
                await SaveLoadManager.Instance.SavePlayerData(this, propertyName);
            }
            else
            {
                Console.WriteLine("SaveLoadManager not found! Make sure it's in the scene.");
            }
        }
    }
}
