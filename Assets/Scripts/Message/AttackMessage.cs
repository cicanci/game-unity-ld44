
public class AttackMessage
{
    public CharacterType Type;
    public float Attack;
}

public class PlayerAttackMessage : AttackMessage
{
    public PlayerAttackMessage()
    {
        Type = CharacterType.Player;
    }
}

public class EnemyAttackMessage : AttackMessage
{
    public EnemyAttackMessage()
    {
        Type = CharacterType.Enemy;
    }
}
