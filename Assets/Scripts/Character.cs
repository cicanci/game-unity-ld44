using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Text _characterLifeText = null;

    [SerializeField]
    private DefaultStats _defaultStats = null;

    private CharacterStats _characterStats;

    private void Start()
    {
        _characterStats = new CharacterStats(_defaultStats);
    }

    public void IncreaseAttribute(AttributeType type)
    {
        switch (type)
        {
            case AttributeType.Attack:
                _characterStats.IncrementAttack();
                break;
            case AttributeType.Defense:
                _characterStats.IncrementDefense();
                break;
            default:
                break;
        }

        UpdateCharacterInfo();
    }

    private void UpdateCharacterInfo()
    {
        _characterLifeText.text = string.Format("HP: {0}", _characterStats.Life);
    }
}
