   M S B A M L   `   `   `  ����  MultiSystem>    8MultiSystem.app.Library.Views.Controls.EditAndDeleteBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��900��5   7   $	��600��6C   
�������.��5      �   � RowDefinitions  5	   
   �� 5
      $
��70.5 �6   �� 5      $
��46.5 �6   �� 5      $	��81* �6   �� 5      $��84 �6   �� 5      $	��19* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��216 �6   �� 5      $	��454 �6   �� 5      $	��150 �6   �� 5      .+�5   
   �� $��0��6   $��Acciones con los libros.��6   $��Center=�6@   $	��362��6]   ���	#FF252525$��Arial)�6�   $��32(�6�   $��2��6�   $��Center=�6�   $��62��6�   $��	42,8,50,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dataBooks��5         
IsReadOnly .    AutoGenerateColumns . $��1��6�   $
��Left=�6�   $��2��6�   $
��auto��6�   $	��800��6�      MinColumnWidth$	 112Q�6�   $��
10,10,0,10q�6�   $��3��6�   6  �� 5   
   -   5         ��Name$ 
buttonEdit��5      $��Editar��6%   $	��120��66   $��40��6B   ���	#FF065523
�������$��3��6x   $��2��6�   $��Center=�6�   $��Right=�6�   $��14(�6�   $
��0,22q�6�   �� 5   
   -   5        $ buttonDelete��5      $��Eliminar��6'   $	��134��6:   $��40��6F   ���	#FF890707
�������$��3��6|   $��2��6�   $��Center=�6�   $
��Left=�6�   $��14(�6�   $
��0,22q�6�   �� 5   
   -   5         ��Name$ searchBooksField��5      $��2��6,   $
��Left=�6<   $��30��6W   $��	22,10,0,6q�6c   $��1��6v    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $��Center=�6�   $	��332��6�   $��Medium"�6�   $��16(�6�   6�   �� 5   
   $��Buscar libro��6   $��1��6'   $��Center=�67   $��	98,9,10,6q�6T   $��1��6g   $��Center=�6t   $	��108��6�   $��16(�6�   $��31��6�   5      5      