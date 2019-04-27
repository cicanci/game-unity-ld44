using UnityEngine;

public class CharacterPlayer : Character
{
    private void OnEnable()
    {
        MessageManager.Instance.AddListener<EnemyAttackMessage>(OnEnemyAttackMessage);
    }

    private void OnDisable()
    {
        MessageManager.Instance.RemoveListener<EnemyAttackMessage>(OnEnemyAttackMessage);
    }

    private void OnEnemyAttackMessage(EnemyAttackMessage message)
    {
        float damage = GetDamage(message.Attack);
        _characterStats.TakeDamage(damage);
        UpdateCharacterInfo();
#if DEBUG
        Debug.LogFormat("[HP: {0} AT: {1} DF: {2}] {3} took {4} damage", 
            _characterStats.Life, _characterStats.Attack, _characterStats.Defense, name, damage);
#endif
    }
}
