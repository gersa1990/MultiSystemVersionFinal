   M S B A M L   `   `   `  ����  MultiSystemD    >MultiSystem.app.Financial.Views.Controls.ReprintBillingService   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��800��5   7   $	��600��6C   .��5      � 
�������  � ColumnDefinitions  5	   
   �� 5
      $��1* �6   �� 5      $	��708 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��54 �6   �� 5      $	��318 �6   �� 5      $��49 �6   �� 5      .+�5   
   �� $��   REIMPRIMIR SERVICIO��6   $	��391��61   $��32(�6=   $��Stencil)�6K   $��1��6a   $��159,12,158,6q�6q   $��Center=�6�   �� 5   
   -   5         ��Name$ serviceToReprint��5      $��1��6,   $��Right=�6<   $��30��6X   $��
0,14,44,10q�6d    �� TextWrapping$
 Wrap=�6x   $��Center=�6�   $	��446��6�   $��1��6�   �� 5   
   $!��Buscar por folio o paciente��6   $��1��66   $
��Left=�6F   $��
10,12,0,10q�6a   $��Center=�6u   $	��203��6�   $��32��6�   $��16(�6�   $��1��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataPatientsGrids��5         
IsReadOnly .    AutoGenerateColumns . $��1��6�   $
��Left=�6�   $��2��6�   $	��Top=�6�   $	��316��6�   $	��708��6�   6�   �� 5   
   -   5         ��Name$ reprintService��5      $��
Reimprimir��6)   $	��120��6>   $��30��6J   ���	#FF065523
�������$��3��6�   $��1��6�   $��Right=�6�   $��0,0,10,0q�6�   $��Center=�6�   6�   �� 5   
   -   5        $ deleteService��5      $��Eliminar��6(   $	��120��6;   $��30��6G   ���	#FF890707
�������$��3��6}   $��1��6�   $��Center=�6�   $��195,12,393,7q�6�   $��Center=�6�   6�   �� 5   
   -   5        $ editService��5      $��Editar��6&   $	��120��67   $��30��6C   ���	#FF1B308F
�������$��3��6y   $��1��6�   $
��Left=�6�   $��10,0,0,0q�6�   $��Center=�6�   6�   �� 5   
   -   5        $ cancelServiceBtn��5      $��Cancelar servicio��6+   $	��148��6G   $��30��6S   ���	#FF1D1616
�������$��3��6�   $��1��6�   $��Center=�6�   $��383,13,177,6q�6�   $��Center=�6�   6�   5      5      