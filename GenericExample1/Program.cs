using System.Collections.Generic;

namespace Generics
{
    public class Task
    {
        static void Main(string[] args)
        {
             // Создаем геймобъект.
            var gameObject = new GameObject();
            
            // Добавляем компонент Rigidbody к геймобъекту.
            gameObject.AddComponent<Rigidbody>();
            // Добавляем компонент Animator к геймобъекту.
            gameObject.AddComponent<Animator>();
            
            // Получаем компонент геймобъекта Rigidbody.
            var rigidbody = gameObject.GetComponent<Rigidbody>();
            // Получаем компонент геймобъекта Animator.
            var animator = gameObject.GetComponent<Animator>();
            // Получаем компонент геймобъекта Transform.
            var transform = gameObject.GetComponent<Transform>(); // Метод возвращает null,
                                                                  // т.к. данный компонент не добавлен к объекту.
        }
    }

     public class GameObject
    {
        private readonly List<IComponent> _components = new List<IComponent>();

        /// <summary>
        /// Метод добавляет компонент к объекту.
        /// </summary>
        public void AddComponent<T>() where T : class, IComponent, new()
        {
            var component = new T(); // Создаем объект переданного типа.
            _components.Add(component); // Добавляем его в список компонентов.
        }

        /// <summary>
        /// Метод получает компонент объекта.
        /// </summary>
        public T GetComponent<T>() where T : class, IComponent
        {
            // Ищем компонент нужного типа в списке компонентов.
            foreach (var component in _components)
            {
                if (component is T typedComponent)
                {
                    return typedComponent; // Если найден, возвращаем.
                }
            }

            return null; // Если не найден, возвращаем null.
        }
    }

    public interface IComponent
    {
    }

    public class Transform : IComponent
    {
        public float X;
        public float Y;
        public float Z;
    }

    public class Animator : IComponent
    {
        public void PlayAnimation()
        {
        }

        public void StopAnimation()
        {
        }
    }

    public class Rigidbody : IComponent
    {
        public float Mass;
        public float Drag;
        public float UseGravity;
    }
}