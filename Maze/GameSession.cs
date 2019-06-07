using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Maze
{
    public class GameSession: BaseNotification
    {

        int[,] s1 = new int[21, 7] { { 0, 0, 0, 0, 0, 0, 0 },
                                    { 0, 1,1,1,1,1,0 },
                                    { 0, 1,0,0,0,1,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 0,0,1,0,1,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 0,0,0,0,0,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 0,0,1,0,1,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 1,0,1,0,1,0 },
                                    { 0, 1,0,1,1,1,0 },
                                    { 0, 0,0,0,0,0,0 },
                                    { 0, 1,0,1,1,1,0 },
                                    { 0, 1,0,1,0,1,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 1,0,1,0,1,0 },
                                    { 0, 1,0,1,0,1,0 },
                                    { 0, 0,0,0,0,0,0 },
                                    { 0, 0,0,0,0,0,0 },
                                    { 0, 0,0,0,0,0,0 } };
        int[,] s2 = new int[21, 7] { { 0, 0, 0, 0, 0, 0, 0 },
                                    { 0, 1,0,1,1,1,0 },
                                    { 0, 1,0,1,0,1,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 1,0,0,0,1,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 0,0,0,0,1,0 },
                                    { 0, 1,1,1,1,1,0 },
                                    { 0, 1,0,0,0,0,0 },
                                    { 0, 1,1,1,1,1,0 },
                                    { 0, 0,0,0,0,1,0 },
                                    { 0, 1,1,1,1,1,0 },
                                    { 0, 1,0,0,0,0,0 },
                                    { 0, 1,0,1,1,1,0 },
                                    { 0, 1,0,1,0,1,0 },
                                    { 0, 1,1,1,0,1,0 },
                                    { 0, 0,0,0,0,1,0 },
                                    { 0, 1,1,1,1,1,0 },
                                    { 0, 1,0,0,0,0,0 },
                                    { 0, 1,0,0,0,0,0 },
                                    { 0, 1,0,0,0,0,0 } };


        public Slider Slider1 { get; set; }
        public Slider Slider2 { get; set; }
        public List<Nail> Nails { get; set; } = new List<Nail>();
        private int _moveCount;

        public int MoveCount
        {
            get { return _moveCount; }
            set
            {
                _moveCount = value;
                OnPropertyChanged(nameof(MoveCount));
            }
        }

        public bool CanS1Up
        {
            get
            {
                // True if the space below each nail is open
                return (Slider1.IsOpen(Nails[0], 1) &&
                        Slider1.IsOpen(Nails[1], 1) &&
                        Slider1.IsOpen(Nails[2], 1));
            }
        }
        public bool CanS1Down
        {
            get
            {
                // True if the space below each nail is open
                return (Slider1.IsOpen(Nails[0], -1) &&
                        Slider1.IsOpen(Nails[1], -1) &&
                        Slider1.IsOpen(Nails[2], -1));
            }
        }
        public bool CanS2Up
        {
            get
            {
                // True if the space below each nail is open
                return (Slider2.IsOpen(Nails[0], 1) &&
                        Slider2.IsOpen(Nails[1], 1) &&
                        Slider2.IsOpen(Nails[2], 1));
            }
        }
        public bool CanS2Down
        {
            get
            {
                // True if the space below each nail is open
                return (Slider2.IsOpen(Nails[0], -1) &&
                        Slider2.IsOpen(Nails[1], -1) &&
                        Slider2.IsOpen(Nails[2], -1));
            }
        }

        public bool CanN0Left
        {
            get
            {
                return (Nails[0].IsOpen(Slider1, -1) &&
                        Nails[3].IsOpen(Slider2, -1));
            }
        }
        public bool CanN1Left
        {
            get
            {
                return (Nails[1].IsOpen(Slider1, -1) &&
                        Nails[4].IsOpen(Slider2, -1));
            }
        }
        public bool CanN2Left
        {
            get
            {
                return (Nails[2].IsOpen(Slider1, -1) &&
                        Nails[5].IsOpen(Slider2, -1));
            }
        }
        public bool CanN0Right
        {
            get
            {
                return (Nails[0].IsOpen(Slider1, 1) &&
                        Nails[3].IsOpen(Slider2, 1));
            }
        }
        public bool CanN1Right
        {
            get
            {
                return (Nails[1].IsOpen(Slider1, 1) &&
                        Nails[4].IsOpen(Slider2, 1));
            }
        }
        public bool CanN2Right
        {
            get
            {
                return (Nails[2].IsOpen(Slider1, 1) &&
                        Nails[5].IsOpen(Slider2, 1));
            }
        }

        public bool HasWon => Slider2.Pos > 16;

        private void UpdateButtons()
        {
            OnPropertyChanged(nameof(CanS1Up));
            OnPropertyChanged(nameof(CanS2Up));
            OnPropertyChanged(nameof(CanS1Down));
            OnPropertyChanged(nameof(CanS2Down));
            OnPropertyChanged(nameof(CanN0Left));
            OnPropertyChanged(nameof(CanN1Left));
            OnPropertyChanged(nameof(CanN2Left));
            OnPropertyChanged(nameof(CanN0Right));
            OnPropertyChanged(nameof(CanN1Right));
            OnPropertyChanged(nameof(CanN2Right));
            OnPropertyChanged(nameof(HasWon));
        }

        public GameSession()
        {
            Slider1 = new Slider(s1);
            Slider2 = new Slider(s2);
            Nails.Add(new Nail(0,0));
            Nails.Add(new Nail(0,1));
            Nails.Add(new Nail(0,2));
            Nails.Add(new Nail(142,3));
            Nails.Add(new Nail(142,4));
            Nails.Add(new Nail(142,5));

        }

        internal void MoveNail(int index)
        {
            MoveCount++;
            if (index < 3)
            {
                Nails[index].Move(-1);
                Nails[index + 3].Move(-1);
            } else
            {
                Nails[index - 3].Move(1);
                Nails[index].Move(1);
            }
            UpdateButtons();
        }

        internal void MoveSlider(int index)
        {
            MoveCount++;
            switch (index)
            {
                case 0:
                    Slider1.Move(-1);
                    break;
                case 1:
                    Slider1.Move(1);
                    break;
                case 2:
                    Slider2.Move(-1);
                    break;
                case 3:
                    Slider2.Move(1);
                    break;
                default:
                    break;
            }
            UpdateButtons();
        }
    }
}