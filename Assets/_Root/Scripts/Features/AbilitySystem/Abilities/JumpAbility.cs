using System;
using UnityEngine;
using JetBrains.Annotations;
using JoostenProductions;

namespace Features.AbilitySystem.Abilities
{
    internal class JumpAbility : IAbility
    {
        private readonly IAbilityItem _abilityItem;

        public JumpAbility([NotNull] IAbilityItem abilityItem) =>
            _abilityItem = abilityItem ?? throw new ArgumentNullException(nameof(abilityItem));


        public void Apply(IAbilityActivator activator)
        {
            var rig = activator.ViewGameObject.GetComponent<Rigidbody2D>();
            Vector3 force = activator.ViewGameObject.transform.up * _abilityItem.Value;
            rig.AddForce(force, ForceMode2D.Force);
        }
    }
}
