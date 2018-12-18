using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Class
{
    class Graphics_Grid
    {

        public static Grid Grid_Title(string str_title)
        {
            //-----------------Label Title----------
            Label title = new Label();
            title.Content = str_title;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.VerticalAlignment = VerticalAlignment.Top;


            //-----------------Grid Title-----------
            Grid gridtitle = new Grid();
            gridtitle.Children.Add(title);
            gridtitle.Margin = new Thickness(300, 0, 300, 0);
            DockPanel.SetDock(gridtitle, Dock.Top);

            return gridtitle;
        }

        public static Grid Grid_Text(ref TextBox txt, string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Grid Grid_Text(ref TextBox txt, string str_lbl, string str_txt, ref Border borderror, string str_error, string str_error_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Children.Add(Block_Error(borderror, str_error, str_error_txt));
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Grid Grid_Pass(ref PasswordBox txt, string str_lbl, string str_txt, ref Border borderror, string str_error, string str_error_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Children.Add(Block_Error(borderror, str_error, str_error_txt));
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Border Block_Error(Border borderror, string str_error, string str_error_txt)
        {
            //--------------------Error TextBlock------------
            TextBlock error = new TextBlock();
            error.Name = str_error;
            error.Text = str_error_txt;
            error.Foreground = Brushes.Red;
            error.HorizontalAlignment = HorizontalAlignment.Center;
            error.VerticalAlignment = VerticalAlignment.Center;


            //--------------------Error TextBlock-------------
            borderror.BorderThickness = new Thickness(1);
            borderror.BorderBrush = Brushes.Red;
            borderror.Child = error;
            borderror.HorizontalAlignment = HorizontalAlignment.Left;
            borderror.Margin = new Thickness(400, 0, 0, 0);
            borderror.Width = 200;
            borderror.Visibility = Visibility.Collapsed;

            return borderror;
        }

        public static Grid Grid_Combo(string str_lbl, string str_txt, List<string> listItems)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------ComboBox-----------------
            ComboBox combo = new ComboBox();
            combo.ItemsSource = listItems;
            combo.Name = str_txt;
            combo.HorizontalAlignment = HorizontalAlignment.Right;
            combo.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(combo);
            grid.Margin = new Thickness(300, 10, 300, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Grid Grid_Time(string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TimeControl-----------------
            TimeControl txt = new TimeControl();
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Right;
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Margin = new Thickness(300, 10, 300, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Grid Grid_Date(ref DatePicker date, string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------DatePicker-----------------
            date.Name = str_txt;
            date.HorizontalAlignment = HorizontalAlignment.Left;
            date.Margin = new Thickness(150, 0, 0, 0);
            date.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(date);
            grid.Margin = new Thickness(300, 10, 300, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Grid Grid_Button(string str_content, string str_name, RoutedEventHandler action)
        {
            //---------------------Button------------
            Button button = new Button();
            button.Click += new System.Windows.RoutedEventHandler(action);
            button.Content = str_content;
            button.Name = str_name;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.HorizontalAlignment = HorizontalAlignment.Center;

            //--------------------Grid----------------
            Grid gridbutton = new Grid();
            gridbutton.Children.Add(button);
            gridbutton.Margin = new Thickness(400, 10, 400, 0);
            DockPanel.SetDock(gridbutton, Dock.Top);

            return gridbutton;
        }

        public static Grid Grid_Btn_Link(string str_content, string str_name, RoutedEventHandler action)
        {
            //---------------------Button---------------------
            Button button = new Button();
            button.Click += new System.Windows.RoutedEventHandler(action);
            button.Content = str_content;
            button.BorderBrush = Brushes.Transparent;
            button.Background = Brushes.Transparent;
            button.Foreground = Brushes.LightSkyBlue;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.HorizontalAlignment = HorizontalAlignment.Center;


            //--------------------Grid-----------------------
            Grid grid = new Grid();
            grid.Children.Add(button);
            grid.Margin = new Thickness(400, 10, 400, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Grid Grid_Radio(ref List<RadioButton> listradio, string str_name)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(200, 10, 200, 0);
            DockPanel.SetDock(grid, Dock.Top);
            ColumnDefinition coldef;

            for (int i = 0; i < 2; i++)
            {
                coldef = new ColumnDefinition();
                coldef.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(coldef);
            }

            RowDefinition rowdef;
            int index = 0;


            foreach (RadioButton radio in listradio)
            {
                radio.HorizontalAlignment = HorizontalAlignment.Left;

                rowdef = new RowDefinition();
                rowdef.Height = new GridLength(30);
                grid.RowDefinitions.Add(rowdef);
                Grid.SetRow(radio, index);
                Grid.SetColumn(radio, 1);
                grid.Children.Add(radio);

                index++;
            }

            return grid;
        }

        public static Grid Grid_Block(string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBlock-----------------
            TextBlock txt = new TextBlock();
            txt.Text = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Margin = new Thickness(200, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static Grid Grid_Block_Modifiable(ref TextBlock txt, string str_lbl, string str_txt, string str_nom, int index, RoutedEventHandler action)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBlock-----------------
            txt.Text = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);


            //---------------------Modifier----------------
            Button btn = new Button();
            btn.Content = "modifier";
            btn.Name = str_nom;
            btn.Tag = index;
            btn.Click += action;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.Margin = new Thickness(500, 0, 0, 0);


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Children.Add(btn);
            grid.Margin = new Thickness(200, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        public static DataGrid DataGrid<T>(ObservableCollection<T> collection, List<string> data, EventHandler<DataGridCellEditEndingEventArgs> action)
        {
            DataGrid grid = new DataGrid();
            grid.CanUserAddRows = false;
            grid.CanUserDeleteRows = false;
            grid.AutoGenerateColumns = false;
            grid.CellEditEnding += action;
            grid.ItemsSource = collection;
            grid.Margin = new Thickness(100, 10, 100, 0);
            DockPanel.SetDock(grid, Dock.Top);
            
                             
            return grid;
        }

        public static DataGridTextColumn Column(string str)
        {
            DataGridTextColumn coldef = new DataGridTextColumn();
            coldef.Header = str;
            coldef.Binding = new Binding(str);
            coldef.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            return coldef;
        }

        public static DataGridComboBoxColumn Column(string header, string bind, List<string> combo)
        {
            DataGridComboBoxColumn coldef = new DataGridComboBoxColumn();
            coldef.Header = header;
            coldef.ItemsSource = combo;
            coldef.SelectedValueBinding = new Binding(bind);
            coldef.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            return coldef;
        }

        public static DataGridTemplateColumn Column(string header, string content, RoutedEventHandler action, RoutedEventHandler action2)
        {
            DataGridTemplateColumn coldef = new DataGridTemplateColumn { Header = header };
            coldef.Width = new DataGridLength(1, DataGridLengthUnitType.SizeToCells);

            DataTemplate data = new DataTemplate();

            FrameworkElementFactory panel = new FrameworkElementFactory(typeof(StackPanel));
            panel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);


            FrameworkElementFactory btn = new FrameworkElementFactory(typeof(Button));
            btn.SetValue(Button.ContentProperty, content);
            btn.SetBinding(Button.CommandParameterProperty, new Binding("Id"));
            btn.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(action));
            btn.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(action2));
            panel.AppendChild(btn);

            data.VisualTree = panel;
            coldef.CellTemplate = data;

            return coldef;
        }
    }
}
