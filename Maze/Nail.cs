using System;

namespace Maze
{
    public class Nail:BaseNotification
    {

        public int Index { get; set; }

        private int _left;

        public int Left
        {
            get { return _left; }
            set {
                _left = value;
                OnPropertyChanged(nameof(Left));
            }
        }
        private int _pos;

        public int Pos
        {
            get { return _pos; }
            set {
                _pos = value;
                Left = 35 + Pos * 20 + Offset;
            }
        }

        public int Offset { get; set; }

        public Nail(int offset, int index)
        {
            Index = index;
            Offset = offset;
            Pos = 0;
        }

        internal void Move(int dir)
        {
            Pos += dir;
        }

        internal bool IsOpen(Slider slider, int dir)
        {
            int x = Pos + dir + 1; //1 for border
            int y = -slider.Pos // Current slider position
                + (Index % 3) * 6 // offset for which nail
                + 4 // starting position
                + 1; // map border 
            return slider.GetMap(x,y) == 1;
        }
    }
}