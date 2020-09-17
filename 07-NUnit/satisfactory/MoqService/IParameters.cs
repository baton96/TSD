using System;

namespace MoqService
{
    public interface IParameters 
    {
        string name { get; }
        int damage { get; }
        int health { get; }
    }
}

