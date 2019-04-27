using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    private DefaultStats _defaultStats = null;

    [SerializeField]
    private CharacterType _type = default;

    [SerializeField]
    private Text _lifeText = null;

    [SerializeField]
    private Text _attackText = null;

    [SerializeField]
    private Text _defenseText = null;

    private CharacterStats _characterStats;
    private float _timer;

    private void Start()
    {
        _characterStats = new CharacterStats(_defaultStats);
        UpdateCharacterInfo();
    }

    private void Update()
    {
        if(_timer < _characterStats.Speed)
        {
            _timer += Time.deltaTime;
            return;
        }

        _timer = 0;
        Attack();
    }

    public void IncreaseAttribute(AttributeType type)
    {
        switch(type)
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
        _lifeText.text = string.Format("HP: {0}", _characterStats.Life);
        _attackText.text = string.Format("AT: {0}", _characterStats.Attack);
        _defenseText.text = string.Format("DF: {0}", _characterStats.Defense);
    }

    private void Attack()
    {
        Debug.LogFormat("{0} attacking!", _type);
        
        switch(_type)
        {
            case CharacterType.Player:
                break;
            case CharacterType.Enemy:
                break;
            case CharacterType.Boss:
                break;
            default:
                break;
        }
    }
}
