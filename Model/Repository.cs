using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoNetCoreApi.Model
{
    public class DemoRepository : IDemoReposityry
    {
        public static ConcurrentDictionary<string, DemoItem> Items { get; set; } = new ConcurrentDictionary<string, DemoItem>();

        public DemoRepository()
        {
            Add(new DemoItem { Name = "Item1" });
        }

        public IEnumerable<DemoItem> GetAll()
        {
            return Items.Values;
        }

        public void Add(DemoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            Items[item.Key] = item;
        }

        public DemoItem Find(string key)
        {
            DemoItem item;
            Items.TryGetValue(key, out item);
            return item;
        }

        public DemoItem Remove(string key)
        {
            DemoItem item;
            Items.TryRemove(key, out item);
            return item;
        }

        public void Update(DemoItem item)
        {
            Items[item.Key] = item;
        }
    }
}