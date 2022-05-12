using Snake.Tools;
using UnityEngine;
internal class OtherController:BaseController
{
    private readonly IReadOnlySubscriptionProperty<bool> _isGrow;
   

    public OtherController(IReadOnlySubscriptionProperty<bool> isGrow, GameData gameData)
    {
       _isGrow = isGrow;
       
    }

 

 
}