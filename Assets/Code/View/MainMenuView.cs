using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public  class MainMenuView:MonoBehaviour
{
    [SerializeField] private Button StartGameBtn;

    public void Init(UnityAction startGameAction)
    {
        StartGameBtn.onClick.AddListener(startGameAction);
    }

    protected void OnDestroy()
    {
        StartGameBtn.onClick.RemoveAllListeners();
    }

}