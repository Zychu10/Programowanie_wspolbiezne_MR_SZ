using System;

namespace Logic
{
    internal class Ball
    {
        private readonly int _size;
        private int _x;
        private int _y;
        private int _newX;
        private int _newY;

        public Ball(int _size, int _x, int _y, int _newX, int _newY)
        {
            this._size = _size;
            this._x = _x;
            this._y = _y;
            this._newX = _newX;
            this._newY = _newY;
        }
        public int Size { get => _size; }
        public int X { get => _x; }
        public int Y { get => _y; }

        public void positioning(int BoardWidth, int BoardHeight)
        {
            if (_x + _newX >= 0 && _x + _newX <= BoardWidth - _size)
            {
                _x += _newX;
            }
            else
            {
                if (_newX > 0)
                {
                    _x = BoardWidth - _size;
                }
                else
                {
                    _x = 0;
                }
                _newX *= -1;
            }

            if(_y + _newY >= 0 && _y + _newY <= BoardHeight - _size)
            {
                _y += _newY;
            }
            else
            {
                if(_newY > 0)
                {
                    _y = BoardHeight - _size;
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
