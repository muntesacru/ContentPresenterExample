using CommonServiceLocator;
using ContentPresenterExample.Utils;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContentPresenterExample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        #region Properties
        /// <summary>
        /// Property by the ContentPresenter control from MainWindow.xaml
        /// to perform the desired ViewModel initialization, based on the option menu the user
        /// choses.
        /// </summary>
        private ViewModelBase _userControlContext;
        public ViewModelBase UserControlContext
        {
            get { return this._userControlContext; }
            set
            {
                _userControlContext = value;
                this.RaisePropertyChanged(nameof(UserControlContext));
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command that gets invoked when the user choses Item1 action
        /// </summary>
        public ICommand Item1Command => new RelayCommand(() =>
        {
            Task.Delay(100).ContinueWith(t =>
            {
                this._userControlContext = ServiceLocator.Current.GetInstance<Item1ViewModel>();
                //this._userControlContext = SimpleIoc.Default.GetInstance<Item1ViewModel>();
                this.RaisePropertyChanged(nameof(UserControlContext));
            });
        }, () => !this._userControlContext.IsTypeOf<Item1ViewModel>());

        /// <summary>
        /// Command that gets invoked when the user choses Item1 action
        /// </summary>
        public ICommand Item2Command => new RelayCommand(() =>
        {
            Task.Delay(100).ContinueWith(t =>
            {
                this._userControlContext = ServiceLocator.Current.GetInstance<Item2ViewModel>();
                this.RaisePropertyChanged(nameof(UserControlContext));
            });
        }, () => !this._userControlContext.IsTypeOf<Item2ViewModel>());

        /// <summary>
        /// Command that gets invoked when the user choses Item1 action
        /// </summary>
        public ICommand Item3Command => new RelayCommand(() =>
        {
            Task.Delay(100).ContinueWith(t =>
            {
                this._userControlContext = ServiceLocator.Current.GetInstance<Item3ViewModel>();
                this.RaisePropertyChanged(nameof(UserControlContext));
            });
        }, () => !this._userControlContext.IsTypeOf<Item3ViewModel>());
        #endregion
    }
}