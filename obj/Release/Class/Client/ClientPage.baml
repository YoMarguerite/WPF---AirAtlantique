   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp1.Class.ClientWpfApp1.Class.Client  %    WpfApp1.Class.Client.ClientPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:WpfApp1.Class.Client       N� Title$  
ClientPage��.���  � ColumnDefinitions �� $��3* ��� $��* �.+�&   System.Windows.Controls.DataGrid  -   $
��grid��$��0��   CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nom+  $ Prénom�� �� *Prenom+  $
 Mail�� �� *Mail+4  .System.Windows.Controls.DataGridComboBoxColumn  $ 	Civilité��-   civilite��   SelectedValueBinding �� *
Civilite+  $ 
Fidélité�� �� *
Fidelite+  $ Mot de passe�� �� *Mdp+4  .System.Windows.Controls.DataGridTemplateColumn  $ Billet��	   
IsReadOnly	 . 
   CellTemplate
 �� .R��� -   $��Billet��  $ 	Supprimer��	 . 
 �� .R��� -   $��	Supprimer���� $��1�� �� Orientation$ Vertical=�.+��� $��Nouveau Client��$��30(��� $	��Nom���� -   $	��Nom���� $��Prénom���� -   $��Prenom���� $
��Mail���� -   $
��Mail���� $��	Civilité���� -   $��
Cocivilite���� $��
Fidélité���� -	   $��Fidelite���� $��Mot de passe��G� -
   $��Password���� -   $��Nouveau��