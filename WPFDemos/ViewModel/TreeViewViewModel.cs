using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using AutoMapper;
using Business.Model;
using Common;
using Common.Utility;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using WPFDemos.Data;
using WPFDemos.Message;
using WPFDemos.Service;

namespace WPFDemos.ViewModel
{
    public class TreeViewViewModel:ViewModelBase
    {
        private ObservableCollection<MenuModel> _treeData;
        public ObservableCollection<MenuModel> TreeData
        {
            get { return _treeData; }
            set
            {
                _treeData = value;
                RaisePropertyChanged("TreeData");
            }
        }

        private bool _canNew { get; set; }
        public bool CanNew {
            get { return _canNew; }
            set {
                _canNew = value;
                RaisePropertyChanged("CanNew");
            }
        }
        public MenuModel SelectedMenu { get; set; }
        public MenuModel SelectedMenuParent { get; set; }
        public TreeViewItem SelectedTreeViewItem { get; set; }

        public RelayCommand<RoutedEventArgs> SelectTreeNodeCommand { get; set; }
        public RelayCommand<KeyEventArgs> KeyDownCommand { get; set; }
        public RelayCommand<RoutedEventArgs> NewCommand { get; set; }
        public RelayCommand<RoutedEventArgs> RenameCommand { get; set; }
        public RelayCommand<KeyEventArgs> EditMenuNameCommand { get; set; }
        public RelayCommand<RoutedEventArgs> DeleteCommand { get; set; }

        MenuService _menuService;
        UserService _userService;
        public TreeViewViewModel ()
        {
            _userService = new UserService();
            _menuService = new MenuService();

            SelectTreeNodeCommand = new RelayCommand<RoutedEventArgs>(SelectTree);
            KeyDownCommand = new RelayCommand<KeyEventArgs>(KeyDown);
            NewCommand = new RelayCommand<RoutedEventArgs>(New,CanNew);
            RenameCommand = new RelayCommand<RoutedEventArgs>(Rename);
            EditMenuNameCommand = new RelayCommand<KeyEventArgs>(EditMenuName);
            DeleteCommand = new RelayCommand<RoutedEventArgs>(Delete);

            var loginResult = _userService.Login();

            var result = _menuService.LoadMenu();
            TreeData = new ObservableCollection<MenuModel>(result.Datas);

            
        }

        private static DependencyObject VisualUpwardSearch<M> (DependencyObject source)
        {
            while(source != null && source.GetType() != typeof(M))
            {
                if(source is Visual || source is Visual3D)
                    source = VisualTreeHelper.GetParent(source);
                else
                    source = LogicalTreeHelper.GetParent(source);
            }
            return source;
        }

        private static DependencyObject GetParent<M> (DependencyObject source)
        {
            if(source == null) return null;

            do
            {
                if(source is Visual || source is Visual3D)
                    source = VisualTreeHelper.GetParent(source);
                else
                    source = LogicalTreeHelper.GetParent(source);
            } while(source != null && source.GetType() != typeof(M));

            return source;
        }

        public void SelectTree (RoutedEventArgs args)
        {
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(args.OriginalSource as DependencyObject) as TreeViewItem;

            var selectedTreeViewItemParent = GetParent<TreeViewItem>(treeViewItem as DependencyObject) as TreeViewItem;

            if(treeViewItem == null) return;

            SelectedTreeViewItem = treeViewItem;
            SelectedMenu = (MenuModel)treeViewItem.Header;

            if(selectedTreeViewItemParent != null)
                SelectedMenuParent = (MenuModel)selectedTreeViewItemParent.Header;

            treeViewItem.Focus();

            CanNew = SelectedMenu != null && (SelectedMenu.Type == 1 || SelectedMenu.Type == 2);

            var e = (MouseButtonEventArgs)args;
            if(e.ChangedButton == MouseButton.Right)
            {
                args.Handled = true;
            }            
        }

        public void KeyDown (KeyEventArgs e)
        {
            if(e.Key == Key.F2)
            {
                Rename(null);
            }
        }

        public void New (RoutedEventArgs e)
        {
            var menuItem = e.Source as MenuItem;
            var header = menuItem.Header.ToString();

            int type = 0;
            if(header.ToLower() == "folder")
            {
                type = 1;
            }
            else if(header.ToLower() == "file")
            {
                type = 2;
            }
            else if(header.ToLower() == "image")
            {
                type = 3;
            }

            var parentId = SelectedMenu.Id;

            var menuDto = new MenuModel
            {
                Name = "New " + header,
                Pid = parentId,
                Type = type
            };

            var addResult = _menuService.AddOrUpdate(menuDto);
            var menu = addResult.Data;
            if(menu != null)
            {               
                SelectedMenu.Id = menu.Id;
                menuDto.Id = menu.Id;
            }
            menuDto.Icon = IconUtility.GetIcon(menuDto.Type);
            menuDto.Parent = SelectedMenu;
            SelectedMenu.Children.Add(menuDto);
        }

        public void Rename (RoutedEventArgs e)
        {
            Messenger.Default.Send(new RenameMenuMessage { TreeViewItem  = SelectedTreeViewItem});
        }

        public void EditMenuName (KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var dto = SelectedMenu;
                _menuService.AddOrUpdate(dto);
                Messenger.Default.Send(new RenameMenuMessage { IsSaved = true,TreeViewItem = SelectedTreeViewItem });
            }
        }

        public void Delete (RoutedEventArgs e)
        {
            var id = SelectedMenu.Id;
            var result = _menuService.Delete(id);
            if(result.Data) {
                if(SelectedMenuParent != null)
                {
                    var removeResult = SelectedMenuParent.Children.Remove(SelectedMenu);
                }
            }
        }
    }
}
