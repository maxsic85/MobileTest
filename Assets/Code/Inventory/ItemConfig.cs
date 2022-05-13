using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ItemMenu")]
public class ItemConfig : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _title;

    public int Id => _id;
    public string Title => _title;
}