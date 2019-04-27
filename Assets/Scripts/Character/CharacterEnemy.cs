using UnityEngine;

public class CharacterEnemy : Character
{
    private void OnEnable()
    {
        MessageManager.Instance.AddListener<PlayerAttackMessage>(OnPlayerAttackMessage);
    }

    private void OnDisable()
    {
        MessageManager.Instance.RemoveListener<PlayerAttackMessage>(OnPlayerAttackMessage);
    }

    private void OnPlayerAttackMessage(PlayerAttackMessage message)
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
