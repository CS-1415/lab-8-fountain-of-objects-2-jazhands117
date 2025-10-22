using System;
using FountainOfObjects.GameDesign;

namespace FountainOfObjects.Interfaces
{
    public interface ICommand
    {
        void Execute(Game game);
    }
}