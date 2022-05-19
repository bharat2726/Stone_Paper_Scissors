//Author : Group 6

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StonePaperScissor
{
    enum UserOptions
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    internal class VM : INotifyPropertyChanged
    {
        public const int UPPER_RANGE = 1;
        public const int LOWER_RANGE = 4;
        int userCount = 0;
        int computerCount = 0;

        private string score = "0:0";
        public string Score
        {
            get { return score; }
            set { score = value; propertyChanged(); }
        }

        public int UserCount
        {
            get { return userCount; }
            set { userCount = value; propertyChanged(); }
        }

        public int ComputerCount
        {
            get { return computerCount; }
            set { computerCount = value; propertyChanged(); }
        }

        private string message = "";
        public string Message
        {
            get { return message; }
            set { message = value; propertyChanged(); }
        }

        private bool scoreBoard;
        public bool ScoreBoard
        {
            get { return scoreBoard; }
            set { scoreBoard = value; propertyChanged(); }
        }

        private bool userImage = true;
        public bool UserImage
        {
            get { return userImage; }
            set { userImage = value; propertyChanged(); }
        }

        private bool rockImage;
        public bool RockImage
        {
            get { return rockImage; }
            set { rockImage = value; propertyChanged(); }
        }

        private bool paperImage;
        public bool PaperImage
        {
            get { return paperImage; }
            set { paperImage = value; propertyChanged(); }
        }

        private bool scissorsImage;
        public bool ScissorsImage
        {
            get { return scissorsImage; }
            set { scissorsImage = value; propertyChanged(); }
        }

        private bool computerImage = true;
        public bool ComputerImage
        {
            get { return computerImage; }
            set { computerImage = value; propertyChanged(); }
        }

        private bool computerRockImage;
        public bool ComputerRockImage
        {
            get { return computerRockImage; }
            set { computerRockImage = value; propertyChanged(); }
        }

        private bool computerPaperImage;
        public bool ComputerPaperImage
        {
            get { return computerPaperImage; }
            set { computerPaperImage = value; propertyChanged(); }
        }

        private bool computerScissorsImage;
        public bool ComputerScissorsImage
        {
            get { return computerScissorsImage; }
            set { computerScissorsImage = value; propertyChanged(); }
        }

        public UserOptions CalculateMove(UserOptions optionName)
        {
            Random r = new Random();
            UserOptions systemOption = (UserOptions)r.Next(UPPER_RANGE, LOWER_RANGE);

            if (optionName == systemOption)
            {
                Message = "Tie";
            }
            else
            {
                if (optionName == UserOptions.Rock && systemOption == UserOptions.Scissors
                    || optionName == UserOptions.Scissors && systemOption == UserOptions.Paper
                    || optionName == UserOptions.Paper && systemOption == UserOptions.Rock)
                {
                    UserCount++;
                    Message = "You Win!!";
                }
                else
                {
                    ComputerCount++;
                    Message = "You Lose!!";
                }
            }
            return systemOption;
        }

        public void EndGame()
        {
            SetEndVisibility();

            if (userCount > computerCount)
                Message = "You Won the match!";
            else if (userCount == computerCount)
                Message = "Tie Match!";
            else
                Message = "You Lost the match!";

            UserCount = 0;
            ComputerCount = 0;
            Score = $"{userCount}:{computerCount}";
        }

        public void SetStartVisibility() //Start Button Visibility
        {
            ScoreBoard = true;
            UserImage = false;
            RockImage = true;
            PaperImage = true;
            ScissorsImage = true;
        }

        public void SetEndVisibility() //End Button Visibility
        {
            DefaultVisibility();
            ScoreBoard = false;
            UserImage = true;
            RockImage = false;
            PaperImage = false;
            ScissorsImage = false;
        }

        public void DefaultVisibility()
        {
            ComputerRockImage = false;
            ComputerPaperImage = false;
            ComputerScissorsImage = false;
            ComputerImage = true;
        }

        public void ToggleVisibility(UserOptions OptionName)
        {
            switch (OptionName)
            {
                case UserOptions.Rock:
                    ComputerImage = false;
                    ComputerRockImage = true;
                    break;

                case UserOptions.Paper:
                    ComputerImage = false;
                    ComputerPaperImage = true;
                    break;

                case UserOptions.Scissors:
                    ComputerImage = false;
                    ComputerScissorsImage = true;
                    break;
            }
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
