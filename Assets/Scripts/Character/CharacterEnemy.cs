using System;
using System.Collections;
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
        _animator.Play("EnemyDamage", 0, 0);

        float damage = GetDamage(message.Attack);
        _characterStats.TakeDamage(damage);
        UpdateCharacterInfo();

#if DEBUG
        Debug.LogFormat("[HP: {0} AT: {1} DF: {2}] {3} took {4} damage",
            _characterStats.Life, _characterStats.Attack, _characterStats.Defense, name, damage);
#endif

        if(_characterStats.Life <= 0)
        {
            StartCoroutine(EnemyKilled());
        }
    }

    private IEnumerator EnemyKilled()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
