﻿namespace KingSurvival4
{
    using System;

    /// <summary>
    /// The 'Component' abstract class for Decorator pattern and Simple Factory pattern
    /// </summary>
    public abstract class Figure
    {
        public Figure(Position position, char name, char symbol)
        {
            this.Position = position;
            this.Name = name;
            this.Symbol = symbol;
        }

        public Position Position { get; set; }

        public char Name { get; set; }

        public char Symbol { get; set; }

        public Memento SaveMemento()
        {
            return new Memento(this.Position, this.Name, this.Symbol);
        }

        public object Clone()
        {
            Figure newFigure = (Figure)this.MemberwiseClone();
            newFigure.Position = (Position)this.Position.Clone();
            return newFigure;
        }
    }
}