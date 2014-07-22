﻿namespace KingSurvival4
{
    /// <summary>
    /// The 'Decorator' abstract class which enables to extend the class Figure
    /// </summary>
    public abstract class FigureDecorator : Figure
    {
        public Figure Figure { get; set; }

        public FigureDecorator(Figure figure)
            : base(figure.Position, figure.Name, figure.Symbol)
        {
            this.Figure = figure;
        }
    }
}