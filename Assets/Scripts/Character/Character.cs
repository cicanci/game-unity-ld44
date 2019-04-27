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

    private float _timer;

    protected CharacterStats _characterStats;

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

    private void Attack()
    {
        switch (_type)
        {
            case CharacterType.Player:
                MessageManager.Instance.SendMessage(new PlayerAttackMessage { Attack = _characterStats.Attack });
                break;
            case CharacterType.Enemy:
                MessageManager.Instance.SendMessage(new EnemyAttackMessage { Attack = _characterStats.Attack });
                break;
            default:
                break;
        }
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

    protected void UpdateCharacterInfo()
    {
        _lifeText.text = string.Format("HP: {0}", _characterStats.Life);
        _attackText.text = string.Format("AT: {0}", _characterStats.Attack);
        _defenseText.text = string.Format("DF: {0}", _characterStats.Defense);
    }

    protected float GetDamage(float attackReceived)
    {
        return attackReceived * attackReceived / (attackReceived + _characterStats.Defense);
    }
}
