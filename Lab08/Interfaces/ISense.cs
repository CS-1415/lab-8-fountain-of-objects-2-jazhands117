using System;
using FountainOfObjects.GameDesign;

namespace FountainOfObjects.Interfaces
{
    public interface ISense
    {
        bool Detect(Game game);
        void Notify(Game game);
    }
}