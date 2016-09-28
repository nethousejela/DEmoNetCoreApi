using System.Collections.Generic;

namespace DemoNetCoreApi.Model
{
    public interface IDemoReposityry
    {
        void Add(DemoItem item);
        IEnumerable<DemoItem> GetAll();
        DemoItem Find(string ket);
        DemoItem Remove(string key);
        void Update(DemoItem item);
    }
}
