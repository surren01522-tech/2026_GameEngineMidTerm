using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Game/Create ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("score Value")]
    public int point = 10;
}
