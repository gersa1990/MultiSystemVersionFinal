   M S B A M L   `   `   `  ����  MultiSystem8    2MultiSystem.app.Library.Views.Controls.RefundBooks   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��900��5   7   $	��600��6C   
�������.��5      �   � ColumnDefinitions  5	   
   �� 5
      $	��27* �6   �� 5      $	��162 �6   �� 5      $	��117 �6   �� 5      $	��339 �6   �� 5      $	��178 �6   �� 5      $	��25* �6    � RowDefinitions 5   
   �� 5      $��71 �6   �� 5      $��43 �6   �� 5      $��40 �6   �� 5      �� 5      $��64 �6   �� 5      $��48 �6   .+�5   
   �� $��0��6   $$��        Devolución de libros
��6   $��Center=�6I   $	��448��6f   ���	#FF252525$��Arial)�6�   $��32(�6�   $��Center=�6�   $��61��6�   $��4,10,4,0q�6�   $��2��6�   $��2��6�   �� 5   
   -   5         ��Name$ searchBooksField��5      $��Center=�6,   $��30��6I   $��0q�6U   $��1��6`    �� TextWrapping$
 Wrap=�6m   $�� ��6�   $��Center=�6�   $	��332��6�   $��Medium"�6�   $��16(�6�   $��3��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataResults��5         
IsReadOnly .    AutoGenerateColumns . $
��Left=�6�   $��3��6�   $
��auto��6�   $	��784��6�      MinColumnWidth$	 112Q�6�   $��5,4,0,10q�6�   $��1��6  $��4��6  �� 5   
   $$��Buscar libro, código o lector��6   $��Center=�68   $��10,6,5,6q�6U   $��1��6g   $��Center=�6t   $	��264��6�   $��16(�6�   $��31��6�   $��1��6�   $��2��6�   �� 5   
   $��Selecciona un libro��6   $��Center=�6.   $��0q�6K   $��2��6V   $��Center=�6c   $	��180��6~   $��30��6�   $��3��6�   �� 5   
   -   5         ��Name$ buttonRefund��5      $��Devolver��6'   $	��120��6:   $��30��6F   ���	#FF065523
�������$��4��6|   $��4��6�   $��Center=�6�   $��Right=�6�   $��
0,17,20,17q�6�   5       5!      