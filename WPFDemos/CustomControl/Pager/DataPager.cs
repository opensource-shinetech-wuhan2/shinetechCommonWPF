using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFDemos.CustomControl.Pager
{
    public class DataPager :Control
    {
        private const string PART_CONTENT_NAME = "PART_Content";
        private const string PART_FIRSTPAGE_NAME = "PART_Firstpage";
        private const string PART_LASTPAGE_NAME = "PART_Lastpage";
        private const string PART_PREVIOUSPAGE_NAME = "PART_Previouspage";
        private const string PART_NEXTPAGE_NAME = "PART_Nextpage";
        private const string PART_COUNT_NAME = "PART_Count";
        private const string PART_PAGEINDEX_NAME = "PART_PageIndex";
        private const string PART_PAGESIZE_NAME = "PART_PageSize";

        private ImageButton PART_Firstpage;//firstpage button
        private ImageButton PART_Lastpage;//lastpage button
        private ImageButton PART_Previouspage;//previous page button
        private ImageButton PART_Nextpage;//next page button
        private StackPanel PART_Content;//indexbutton container
        private TextBlock PART_Count;
        private TextBlock PART_PageIndex;
        private ComboBox PART_PageSize;

        private int currentFocusButtonIndex = 1;
        private int actualNumericButtonCount = 0;

        public int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set { SetValue(TotalProperty,value); }
        }
        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total",typeof(int),typeof(DataPager),new PropertyMetadata(0));

        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty,value); }
        }
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount",typeof(int),typeof(DataPager),new PropertyMetadata(0));

        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty,value); }
        }
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize",typeof(int),typeof(DataPager),new PropertyMetadata(10));

        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty,value); }
        }
        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex",typeof(int),typeof(DataPager),new PropertyMetadata(0));

        public int NumericButtonCount
        {
            get { return (int)GetValue(NumericButtonCountProperty); }
            set { SetValue(NumericButtonCountProperty,value); }
        }
        public static readonly DependencyProperty NumericButtonCountProperty =
            DependencyProperty.Register("NumericButtonCount",typeof(int),typeof(DataPager),new PropertyMetadata(5));

        public class PageChangedEventArgs :RoutedEventArgs
        {
            public int PageIndex { get; set; }

            public int PageSize { get; set; }

            public PageChangedEventArgs (int pageIndex,int pageSize)
                : base()
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
            }
        }

        public static readonly RoutedEvent PageChangedEvent = EventManager.RegisterRoutedEvent("PageChanged",
                     RoutingStrategy.Bubble,typeof(EventHandler<PageChangedEventArgs>),typeof(DataPager));


        public event EventHandler<PageChangedEventArgs> PageChanged
        {
            add
            {
                AddHandler(PageChangedEvent,value);
            }
            remove
            {
                RemoveHandler(PageChangedEvent,value);
            }
        }

        private void GenerateContent ()
        {
            PageIndex = 1;            
            currentFocusButtonIndex = 1;
            PageCount = (int)Math.Ceiling((double)Total / PageSize);

            PART_Content.Children.Clear();
            if(PageCount <= NumericButtonCount)
            {
                for(int i = 0; i < PageCount; i++)
                {
                    var linkBtn = new PagerIndexButton { Content = (i + 1).ToString() };
                    linkBtn.Click += LinkBtn_Click;
                    PART_Content.Children.Add(linkBtn);
                }

                actualNumericButtonCount = PageCount;
            }
            else
            {
                for(int i = 0; i < NumericButtonCount; i++)
                {
                    var linkBtn = new PagerIndexButton { Content = (i + 1).ToString() };
                    linkBtn.Click += LinkBtn_Click;
                    PART_Content.Children.Add(linkBtn);
                }

                actualNumericButtonCount = NumericButtonCount;
            }
            
            if(PART_Content.Children.Count > 0) SetLinkButtonFocus(1);
            SetButtonEnable();
        }

        public override void OnApplyTemplate ()
        {
            base.OnApplyTemplate();

            PART_Firstpage = GetTemplateChild(PART_FIRSTPAGE_NAME) as ImageButton;
            PART_Lastpage = GetTemplateChild(PART_LASTPAGE_NAME) as ImageButton;
            PART_Content = GetTemplateChild(PART_CONTENT_NAME) as StackPanel;
            PART_Previouspage = GetTemplateChild(PART_PREVIOUSPAGE_NAME) as ImageButton;
            PART_Nextpage = GetTemplateChild(PART_NEXTPAGE_NAME) as ImageButton;
            PART_Count = GetTemplateChild(PART_COUNT_NAME) as TextBlock;
            PART_PageIndex = GetTemplateChild(PART_PAGEINDEX_NAME) as TextBlock;
            PART_PageSize = GetTemplateChild(PART_PAGESIZE_NAME) as ComboBox;
                                
            Loaded += DataPager_Loaded;
            PART_PageSize.SelectionChanged += PART_PageSize_SelectionChanged;
            PART_Firstpage.Click += PART_Firstpage_Click;//firstpage event
            PART_Lastpage.Click += PART_Lastpage_Click;//last page event
            PART_Previouspage.Click += PART_Previouspage_Click;//previous event           
            PART_Nextpage.Click += PART_Nextpage_Click;//next event

            GenerateContent();
        }

        private void DataPager_Loaded (object sender,RoutedEventArgs e)
        {
            OnPageChanged();
        }

        private void PART_PageSize_SelectionChanged (object sender,SelectionChangedEventArgs e)
        {
            var cmbPageSize = (ComboBox)sender;
            PageSize = Convert.ToInt32(((ComboBoxItem)cmbPageSize.SelectedItem).Content);

            GenerateContent();
            OnPageChanged();
        }

        private void PART_Firstpage_Click (object sender,RoutedEventArgs e)
        {
            PageIndex = 1;

            var index = PageIndex;
            foreach(var item in PART_Content.Children)
            {
                var btn = item as PagerIndexButton;
                var newPageIndex = index;
                btn.Content = newPageIndex;
                index++;
            }
            SetCurrentFocusButtonIndex(PART_Content.Children[0] as PagerIndexButton);
            SetLinkButtonFocus(currentFocusButtonIndex);
            SetButtonEnable();
            OnPageChanged();
        }

        private void PART_Lastpage_Click (object sender,RoutedEventArgs e)
        {
            PageIndex = PageCount;

            var index = PageIndex - actualNumericButtonCount + 1;
            foreach(var item in PART_Content.Children)
            {
                var btn = item as PagerIndexButton;
                var newPageIndex = index;
                btn.Content = newPageIndex;
                index++;
            }

            SetCurrentFocusButtonIndex(PART_Content.Children[actualNumericButtonCount - 1] as PagerIndexButton);
            SetLinkButtonFocus(currentFocusButtonIndex);
            SetButtonEnable();
            OnPageChanged();
        }

        private void SetButtonEnable ()
        {
            if(PageIndex == 1)
            {
                PART_Firstpage.IsEnabled = false;
                if(!PART_Lastpage.IsEnabled) PART_Lastpage.IsEnabled = true;

                PART_Previouspage.IsEnabled = false;
                if(!PART_Nextpage.IsEnabled) PART_Nextpage.IsEnabled = true;
            }
            else if(PageIndex == PageCount)
            {
                PART_Lastpage.IsEnabled = false;
                if(!PART_Firstpage.IsEnabled) PART_Firstpage.IsEnabled = true;

                PART_Nextpage.IsEnabled = false;
                if(!PART_Previouspage.IsEnabled) PART_Previouspage.IsEnabled = true;
            }
            else
            {
                if(!PART_Firstpage.IsEnabled) PART_Firstpage.IsEnabled = true;
                if(!PART_Lastpage.IsEnabled) PART_Lastpage.IsEnabled = true;

                if(!PART_Previouspage.IsEnabled) PART_Previouspage.IsEnabled = true;
                if(!PART_Nextpage.IsEnabled) PART_Nextpage.IsEnabled = true;
            }
        }

        private void PART_Nextpage_Click (object sender,RoutedEventArgs e)
        {
            //last pager button
            if(currentFocusButtonIndex == actualNumericButtonCount && PageIndex < PageCount)
            {
                foreach(var item in PART_Content.Children)
                {
                    var btn = item as PagerIndexButton;
                    var pageIndex = Convert.ToInt32(btn.Content);
                    var newPageIndex = pageIndex + 1;
                    btn.Content = newPageIndex;
                }
            }

            PageIndex++;
            SetButtonEnable();

            if(currentFocusButtonIndex < actualNumericButtonCount) currentFocusButtonIndex++;
            SetLinkButtonFocus(currentFocusButtonIndex);
            OnPageChanged();
        }

        private void PART_Previouspage_Click (object sender,RoutedEventArgs e)
        {
            //first pager button
            if(currentFocusButtonIndex == 1 && PageIndex > 1)
            {
                foreach(var item in PART_Content.Children)
                {
                    var btn = item as PagerIndexButton;
                    var pageIndex = Convert.ToInt32(btn.Content);
                    var newPageIndex = pageIndex - 1;
                    btn.Content = newPageIndex;
                }
            }

            PageIndex--;
            SetButtonEnable();

            if(currentFocusButtonIndex > 1) currentFocusButtonIndex--;
            SetLinkButtonFocus(currentFocusButtonIndex);
            OnPageChanged();
        }

        private void SetLinkButtonFocus (int index)
        {
            PART_Content.Children[index - 1].Focus();
        }

        private void SetCurrentFocusButtonIndex (PagerIndexButton button)
        {
            currentFocusButtonIndex = PART_Content.Children.IndexOf(button) + 1;
        }

        private void LinkBtn_Click (object sender,RoutedEventArgs e)
        {
            var button = sender as PagerIndexButton;
            PageIndex = Convert.ToInt32(button.Content);
            SetCurrentFocusButtonIndex(button);
            SetButtonEnable();
            OnPageChanged();
        }

        private void OnPageChanged ()
        {
            var eventArgs = new PageChangedEventArgs(PageIndex,PageSize) { RoutedEvent = PageChangedEvent,Source = this };
            RaiseEvent(eventArgs);
        }
    }
}
