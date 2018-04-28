using OrientationLayoutDemo.Enums;
using Xamarin.Forms;

namespace OrientationLayoutDemo.Behavior
{
    public class OrientationBehavior : BehaviorBase<View>
    {

        public static readonly BindableProperty OrientationCommandProperty = BindableProperty.Create("OrientationCommand", typeof(Command), typeof(OrientationBehavior), null);
        public Command OrientationCommand
        {
            get { return (Command)GetValue(OrientationCommandProperty); }
            set { SetValue(OrientationCommandProperty, value); }
        }

        private OrientationStatus _orientationStatus;

        protected override void OnAttachedTo(View bindable)
        {
            bindable.SizeChanged += Bindable_SizeChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            bindable.SizeChanged -= Bindable_SizeChanged;
            base.OnDetachingFrom(bindable);
        }

        private void Bindable_SizeChanged(object sender, System.EventArgs e)
        {
            var view = sender as View;

            if (view != null)
            {
                bool isWide = view.Width > 400;
                if (isWide)
                {
                    _orientationStatus = OrientationStatus.Horizontal;
                }
                else
                {
                    _orientationStatus = OrientationStatus.Vertical;
                }
                if (OrientationCommand != null)
                {
                    OrientationCommand.Execute(_orientationStatus.ToString());
                }
            }

        }
    }
}
