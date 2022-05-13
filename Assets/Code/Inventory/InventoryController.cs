using System.Collections.Generic;

public class InventoryController :BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IInventoryView _inventoryView;
    private readonly IRepository<int,IItem> _itemsRepository;

    public InventoryController(IInventoryModel inventoryModel, List<ItemConfig> itemConfigs)
    {
        _inventoryModel = inventoryModel;
        _inventoryView = new InventoryView();
        _itemsRepository = new ItemRepository(itemConfigs);

    }

    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Content.Values)
        {
            _inventoryModel.EquipItem(item);
        }
        var equippedItems = _inventoryModel.GetEquippedItems();
        _inventoryView.DisplayInventory(equippedItems);
    }
}
