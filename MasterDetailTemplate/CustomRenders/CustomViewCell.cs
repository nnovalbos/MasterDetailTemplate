using System;
using Xamarin.Forms;

namespace MasterDetailTemplate.CustomRenders
{
    public class CustomViewCell : ViewCell
    {
       // public static readonly BindableProperty SelectedItemBackgroundColorProperty = BindableProperty.Create("SelectedItemBackgroundColor", typeof(Color), typeof(CustomViewCell), Color.White, BindingMode.TwoWay);

        public static readonly BindableProperty SelectedItemBackgroundColorProperty =
        BindableProperty.Create("SelectedItemBackgroundColor",
                                typeof(Color),
                                typeof(CustomViewCell),
                                Color.Default);

        public static readonly BindableProperty ItemIdentifierProperty =
        BindableProperty.Create("ItemIdentifier",
                                typeof(string),
                                typeof(CustomViewCell),
                                string.Empty);


        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedItemBackgroundColorProperty); }
            set { SetValue(SelectedItemBackgroundColorProperty, value); }
        }

        public string ItemIdentifier
        {
            get { return (string)GetValue(ItemIdentifierProperty); }
            set { SetValue(ItemIdentifierProperty, value); }
        }
    }
}
