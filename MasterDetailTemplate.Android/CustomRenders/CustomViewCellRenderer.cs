using System.ComponentModel;

using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using MasterDetailTemplate.CustomRenders;
using MasterDetailTemplate.Droid.CustomRenders;
using MasterDetailTemplate.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace MasterDetailTemplate.Droid.CustomRenders
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _cellCore;
        private Drawable _unselectedBackground;
        private bool _selected;
        private int creationCounter = 0;
        private bool _hasBeenCreatedAgain = false;
       
        protected override Android.Views.View GetCellCore(Cell item,
                                                          Android.Views.View convertView,
                                                          ViewGroup parent,
                                                          Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);
            creationCounter++;
           

            if (creationCounter > 1)
            {
                _hasBeenCreatedAgain = true;
            }
            else
            {
                //nueva creación
                _selected = false;
                _unselectedBackground = _cellCore.Background;
            }

            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);

            if (args.PropertyName == "IsSelected")
            {


                if (_hasBeenCreatedAgain)
                {
                    _hasBeenCreatedAgain = false;

                    var customCell = sender as CustomViewCell;
                    var list = customCell.Parent as ListView;
                    var selectedItem = list.SelectedItem as MasterDetailMenuItem;

                    // si es la celda seleccionada:
                    if (selectedItem.MenuItemTitle.Equals(customCell.ItemIdentifier))
                    {
                        //se llama 2 veces, una en el giro y otra para 'setear' el valor seleccionado, por este motivo, 
                        //le decimos que está a false

                        _selected = false;
                        return;
                    }
                }


                _selected = !_selected;

                if (_selected)
                {
                    var extendedViewCell = sender as CustomViewCell;
                    _cellCore.SetBackgroundColor(extendedViewCell.SelectedBackgroundColor.ToAndroid());
                }
                else
                {
                    _cellCore.SetBackground(_unselectedBackground);
                }
            }
        }
    }
}
