using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWGameEngine.Core.Library.GameObjects.GameComponents
{
    public class HealthComponent
    {
        private int currentHealth, maxHealth = 100;

        public int Health
        {
            get
            {
                return currentHealth;
            }

            set
            {
                if (currentHealth + value > maxHealth)
                    currentHealth = maxHealth;
                
                currentHealth = value;
            }
        }

        public int MaxHealth 
        {
            get
            {
                return maxHealth;
            }
            set 
            {
                maxHealth = value;

                if (currentHealth > maxHealth)
                    currentHealth = maxHealth;
            } 
        }


    }
}
