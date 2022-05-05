using System;

namespace Logic
{
    internal class Ball
    {
        private int _x;
        private int _y;
        private int _newX;
        private int _newY;

        public Ball(int _x, int _y, int _newX, int _newY)
        {
            this._x = _x;
            this._y = _y;
            this._newX = _newX;
            this._newY = _newY;
        }

        public int X { get => _x; }
        public int Y { get => _y; }

        public void positioning(int BoardWidth, int BoardHeight)
        {
            if (_x + _newX >= 0 && _x + _newX <= BoardWidth)
            {
                _x += _newX;
            }
            else
            {
                if (_newX > 0)
                {
                    _x = BoardWidth;
                }
                else
                {
                    _x = 0;
                }
                _newX *= -1;
            }

            if(_y + _newY >= 0 && _y + _newY <= BoardHeight)
            {
                _y += _newY;
            }
            else
            {
                if(_newY > 0)
                {
                    _y = BoardHeight;
                }
                else
                {
                    _y = 0;
                }
                _newY *= -1;
            }
        }
    }
}
