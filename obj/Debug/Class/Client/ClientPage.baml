   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp1.Class.ClientWpfApp1.Class.Client  5      %    WpfApp1.Class.Client.ClientPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WpfApp1.Class.Client     5        N� Title$  
ClientPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $
��grid��5   ;   $��0��6      CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  ��6#   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Nom+  5      $ Prénom��6%    65   �� *Prenom+  5      $
 Mail��6%    63   �� *Mail+4  .System.Windows.Controls.DataGridComboBoxColumn  5      $ 	Civilité��6)   -   5        civilite��   SelectedValueBinding 5   M   �� *
Civilite+  5      $ 
Fidélité��6%    67   �� *
Fidelite+  5      $ Mot de passe��6%    6;   �� *Mdp+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Billet��6)   	   
IsReadOnly	 . 
   CellTemplate
 5      �� 5      .R�5      �� -   5        $��Billet��5   %   66   5      5        5      $ 	Supprimer��6)   	 . 
 5       �� 5!      .R�5"      �� -   5        $��	Supprimer��5"   %   69   5#      5%      5'      �� 5)   
   $��1��6    �� Orientation$ Vertical=�6%   .+�5*      �� $��Nouveau Client��6   $��30(�6.   �� 5,      $	��Nom��6   �� 5-      -   5        $	��Nom��5-      �� 5/      $��Prénom��6   �� 50      -   5        $��Prenom��50      �� 52      $
��Mail��6   �� 53      -   5        $
��Mail��53      �� 55      $��	Civilité��6   �� 56      -   5        $��
Cocivilite��56      �� 58      $��
Fidélité��6   �� 59      -	   5        $��Fidelite��59      �� 5;      $��Mot de passe��6   G� 5<      -
   5        $��Password��5<      �� 5>      -   5        $��Nouveau��5>      6'   5@      5A      5B      