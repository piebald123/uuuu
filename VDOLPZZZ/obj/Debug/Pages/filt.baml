   M S B A M L   `   `   `  ����C  ?VDOLPZZZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:VDOLPZZZ.PagesVDOLPZZZ.Pages  5          VDOLPZZZ.Pages.filt   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:VDOLPZZZ.Pages     5        N� Title$
  filt��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 SLV��5      $��	0,94,0,41q�6       AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер записи��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Nomer_Zapisi+  5      $# Код предприятия��6%    6>   �� *Kod_Predpriytie+  5      $1 +Наименование продукции��6%    6E   �� *Naimenovanit_Prodykcie+  5      $ Количество��6%    69   �� *Kolichestvo+  5      $ Цена��6%    63   �� *Cena+5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $	��Top=�6;   $
��Left=�6S   $��90,5,0,5q�6n   .+�5      �� $K��EФильтрация по наименованию продукции��6   $��14(�6D   $
��Left=�6R   6o   �� 5      -   5         ��Name$ FiltTbx��5   0   $	��150��6   $	��5 0q�6#    �� SelectedItem$ Filt_SelectedItem��6A   6�   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   $��Bottom=�6;   $��Center=�6V   .+�5      �� -   5        	 ��Name$	 BackBtn��5      $��
Назад��6&   $��5q�66   $��30��6A   $	��150��6M   6q   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   $	��Top=�6;   $
��Left=�6S   $��
600,10,0,5q�6n   5      5      