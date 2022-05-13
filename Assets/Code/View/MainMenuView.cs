using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public  class MainMenuView:MonoBehaviour
{
    [SerializeField] private Button StartGameBtn;
    [SerializeField] private Button ToShopBtn;


    public void Init(UnityAction startGameAction, UnityAction toShopAction)
    {
        StartGameBtn.onClick.AddListener(startGameAction);
        ToShopBtn.onClick.AddListener(toShopAction);

    }

    protected void OnDestroy()
    {
        StartGameBtn.onClick.RemoveAllListeners();
        ToShopBtn.onClick.RemoveAllListeners();
    }

}