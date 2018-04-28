using OrientationLayoutDemo.Behavior;
using OrientationLayoutDemo.Enums;
using System;
using Xamarin.Forms;

namespace OrientationLayoutDemo.ViewModels
{
    public class HomeViewModel : BindableObject
    {
        private Command _orientationcCommand;

        public Command OrientationCommand
        {
            get { return _orientationcCommand; }
            set
            {
                _orientationcCommand = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public HomeViewModel()
        {
            Message = "No Orientation fired yet";
            OrientationCommand = new Command(PropagateMessage);
        }

        private void PropagateMessage(object obj)
        {
            var message = "No view";
            var orientation = obj as string;
            var statusRaw = Enum.Parse(typeof(OrientationStatus), orientation);
            if (statusRaw != null)
            {
                OrientationStatus status = (OrientationStatus)statusRaw;
                switch (status)
                {
                    case OrientationStatus.None:
                        break;
                    case OrientationStatus.Horizontal:
                        message = "This is a Wide Layout";
                        SetOrientationTemplate("HorizontalOrientationTemplate");
                        break;
                    case OrientationStatus.Vertical:
                        message = "Holding device vertically";
                        SetOrientationTemplate("VerticalOrientationTemplate");
                        break;
                    default:
                        break;
                }
            }
            Message = message;
        }
        private void SetOrientationTemplate(string orientationTemplate)
        {
            if (App.Current.Resources != null)
            {
                if (App.Current.Resources.ContainsKey("OrientationTemplate") &&
                    App.Current.Resources.ContainsKey(orientationTemplate))
                {
                    App.Current.Resources["OrientationTemplate"] = App.Current.Resources[orientationTemplate];
                }
            }

        }
    }
}
