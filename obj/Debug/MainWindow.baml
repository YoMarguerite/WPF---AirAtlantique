   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��Regular"�5	   
   $��13(�5
   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
    � Title$ 
MainWindow��5   	   $
��1000��6   $	��700��6)   .��5      ]� -   5        $��
MainLayout��5      .+�5   
   � ���#ef3026$	��Top=�6$   $��30��69    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��4* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� -   5        $��AccueilButton��5      $��0��6*      Accueil#��[  6:    �� 	ClickMode$ Release=�6k   �� 5      -   5        $��
QuitButton��5      $��7��6'     
ButtonMenu#��[ 67   $��Quitter��6[   $ Release=�6}   5       � 5   
   -   5          �Name$
 Main��5        � NavigationUIVisibility$ Hidden=�6   6@   5       5!      