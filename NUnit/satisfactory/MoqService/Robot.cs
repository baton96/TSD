using System;

namespace MoqService
{
    public class Robot
    {
        private IParameters _parameters;
        public Robot(IParameters parameters) 
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            _parameters = parameters;
        }
        public string Name() => _parameters.name;
        public int Damage() => _parameters.damage;
        public int Health() => _parameters.health;

    } 
}
