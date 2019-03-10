using Xamarin.Forms;

namespace MasterDetailTemplate.Views
{
    public partial class NavigationView : NavigationPage
    {
        public NavigationView()
        {
            InitializeComponent();
        }


        public NavigationView(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}
