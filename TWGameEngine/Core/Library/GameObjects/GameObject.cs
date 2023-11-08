using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWGameEngine.Core.Library.GameObjects.GameComponents;

namespace TWGameEngine.Core.Library.GameObjects
{
    public class GameObject
    {
        private static int _id = 0;
        
        public int GameObjectId { get { return _id; } private set { _id = value; } }

        public List<GameComponent> GameObjectComponentsList { get; set; } = new();
        
        public string ShortName { get; set; } = "GameObject";

        public string Description { get; set; } = "This is a GameObject itself.  It is lacking a proper description and should be reported!";

        public GameObject(string shortName, string description) 
        {
            ShortName = shortName;
            Description = description;
            _id++;
        }

        public GameObject(string shortName)
        {
            ShortName = shortName;
            Description = "This is a GameObject itself, and it is lacking a description.";
        }

        public bool HasGameComponent(string componentName)
        {
            for(int i = 0; i < GameObjectComponentsList.Count;i++)
            {
                if(string.Equals(componentName, GameObjectComponentsList[i].ComponentName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public T? GetGameComponent<T>(string componentName) where T : GameComponent
        {
            for(int i = 0; i < GameObjectComponentsList.Count;i++)
            {
                if (string.Equals(componentName, GameObjectComponentsList[i].ComponentName, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)GameObjectComponentsList[i];
                }
            }

            return null;
        }

        public void AddComponent(GameComponent component)
        {
            if (!HasGameComponent(component.ComponentName))
                GameObjectComponentsList.Add(component);
        }

        public void RemoveComponent(GameComponent component)
        {
            if(GameObjectComponentsList.Contains(component)) 
                GameObjectComponentsList.Remove(component);
        }
    }
}
