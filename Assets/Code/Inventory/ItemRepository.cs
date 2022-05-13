using System.Collections.Generic;

public class ItemRepository : BaseController, IRepository<int, IItem>
{
    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();
    public IReadOnlyDictionary<int, IItem> Content => _itemsMapById;

    public ItemRepository(List<ItemConfig> itemConfigs)
    {
        PopulateItems(itemConfigs);
    }

    private void PopulateItems(List<ItemConfig> itemConfigs)
    {
        foreach (var item in itemConfigs)
        {
            if (_itemsMapById.ContainsKey(item.Id))
                continue;
            _itemsMapById.Add(item.Id, CreateItem(item));
        }
    }

    private IItem CreateItem(ItemConfig itemConfig)
    {
        return new Item
        {
            Id = itemConfig.Id,
            IInfo = new ItemInfo { Title = itemConfig.Title }
        };
    }
    protected override void OnChildDispose()
    {
        _itemsMapById.Clear();
        base.OnChildDispose();
    }
}