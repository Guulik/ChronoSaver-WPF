using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChronoSaver.View.UserControls
{

    public partial class ChronoButton : UserControl
    {
        public ChronoButton()
        {
            InitializeComponent();
        }

        private string _contentText = string.Empty;

        public string ContentText
        {
            get { return _contentText; }
            set
            {
                _contentText = value;
                btn.Content = _contentText;
            }
        }

        private Brush _color;
        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                btn.Background = _color;
            }
        }
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
