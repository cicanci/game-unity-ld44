
public class CharacterStats
{
    public float Life { private set; get; }
    public float Attack { private set; get; }
    public float Defense { private set; get; }
    public float Experience { private set; get; }
    public float Speed { private set; get; }

    private DefaultStats _defaultStats;
    private float _upgradeRate = 1;
    private float _upgradeCost = 1;

    public CharacterStats(DefaultStats defaultStats)
    {
        _defaultStats = defaultStats;
        Life = _defaultStats.Life;
        Attack = _defaultStats.Attack;
        Defense = _defaultStats.Defense;
        Experience = _defaultStats.Experience;
        Speed = _defaultStats.Speed;
    }

    public void IncrementAttack()
    {
        Life -= _defaultStats.AttackCost * _upgradeCost;
        Attack += _defaultStats.AttackRate * _upgradeRate;
    }

    public void IncrementDefense()
    {
        Life -= _defaultStats.DefenseCost * _upgradeCost;
        Defense += _defaultStats.DefenseRate * _upgradeRate;
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;
    }
}
