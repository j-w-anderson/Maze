using System;

namespace Maze
{
    public class Slider:BaseNotification
    {
        public int[,] Map { get; set; }

        private int _top;

        public int Top
        {
            get { return _top; }
            set {
                _top = value;
                OnPropertyChanged(nameof(Top));
            }
        }

        private int _pos;

        public int Pos
        {
            get { return _pos; }
            set {
                _pos = value;
                Top = 45 + Pos * 20;
            }
        }


        public Slider(int[,] map)
        {
            Pos = 0;
            Map = map;
        }

        internal void Move(int dir)
        {
            Pos += dir;
        }

        internal bool IsOpen(Nail nail, int dir)
        {
            // return true if space above or below nail is open.
            int x = nail.Pos+1;
            int y = -Pos // Current slider position
                + (nail.Index % 3)*6 // offset for which nail
                + dir // above or below  
                + 4 // starting position
                + 1; // map border 
            return GetMap(x, y) == 1;
        }

        public int GetMap(int x, int y)
        {
            if (x<0 || y<0 ||x>=7 || y>=21 )
            {
                return 1;
            } else
            {
                return Map[y, x];
            }
        }
    }
}