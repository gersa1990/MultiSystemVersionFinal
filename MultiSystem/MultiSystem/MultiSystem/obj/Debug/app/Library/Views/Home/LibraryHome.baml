   M S B A M L   `   `   `  ����F  BMultiSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:MultiSystem.app.Library.Views.Controls&MultiSystem.app.Library.Views.Controls  5   	   _4clr-namespace:MultiSystem.app.Library.Views.Controls&MultiSystem.app.Library.Views.Controls  5      _4clr-namespace:MultiSystem.app.Library.Views.Controls&MultiSystem.app.Library.Views.Controls  5   	   2    ,MultiSystem.app.Biblioteca.Views.LibraryHome   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   DAdd4clr-namespace:MultiSystem.app.Library.Views.Controls     5   	   K
searchBook4clr-namespace:MultiSystem.app.Library.Views.Controls     5      MadminControl4clr-namespace:MultiSystem.app.Library.Views.Controls     5   	   -   5          �Name$  windowLibraryHome��5   	    � Title$ 
Biblioteca��5	   	   $
��1024��5
      $	��608��5       � Left$ 0��5       � WindowStartupLocation$ CenterScreen=�5   	   
 � Top$ 0��5   	   .��5      � -   5         �Name$ gridMainLibrary��5       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      �� 5      $��32 �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ rectangleTop��5      $��0��6*   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67   .��5      �  � Color$ 	#FFD60000��6#    � Offset$ 0Q�65   � 5      $ 	#FF830000��6#   $ 1Q�65   5      5!      �� 5#   
   -   5         ��Name$ controlMain��5#      $
��auto��6Z   $��1��6h   $
��auto��6u    �� TabStripPlacement$
 Left=�6�   .@�5%      �� -   5         ��Name$ adminControl��5%   -   $��Administrador��6   .��5&      � ���	#FFE5E5E5.+�5'      ?   9MultiSystem.app.Library.Views.Controls.AdminControlWindow  5(      5)      �� 5+      -   5        $ addBookItem��5+   '   $��Agregar��6   .��5,      � ���	#FFE5E5E5.+�5-      4   .MultiSystem.app.Library.Views.Controls.AddBook  5.      5/      �� 51      -   5        $��CRUDBook��51   1   $��Editar y Eliminar��6   .��52      � ���	#FFE5E5E5.+�53      >   8MultiSystem.app.Library.Views.Controls.EditAndDeleteBook  54      55      �� 57      -   5        $ loanBook��57   2   $��Solicitar préstamo��6   .��58      � ���	#FFE5E5E5.+�59      1   +MultiSystem.app.Library.Views.Controls.Loan  5:      5;      �� 5=      -	   5        $ 
refundBook��5=   *   $��Devolución��6   .��5>      � ���	#FFE5E5E5.+�5?      8   2MultiSystem.app.Library.Views.Controls.RefundBooks  5@      5A      �� 5D      -
   5        $ printFormats��5D   1   $��Imprimir formatos��6   .��5E      � ���	#FFE5E5E5.+�5F      B   <MultiSystem.app.Library.Views.Controls.PrinterLibraryFormats  5G      5H      5J      �� 5K   
   -   5        $ rectangleBottom��5K      
���   �
���   �$
��auto��6I   $��2��6V   $��0,0,0,-3q�6c   �� 5L   
   -   5         ��Name$ clockBottom��5L      $��Derechos reservados 2014
��6%   
�������$��14(�6`   $��2��6n   $��Right=�6|   $��Center=�6�   $��32��6�   $	��433��6�   $��0,0,4,0q�6�   �� 5M   
   -   5        $ 	nameAdmin��5M      $��2��6   $��Label��60   $
��Left=�6@   $��Center=�6\   $	��398��6w   $��32��6�   
������� J� RenderTransformOrigin$ 
0.527,0.25&�6�   $��14(�6�   �� 5O   
   $��Center=�6   $��286,10,53,10q�61   $
��Wrap=�6G   $��Center=�6[   $��80��6v   $��24(�6�   
�������$��Arial Black)�6�   $	��421��6�   �� 6�   $8�2       HOSPITAL INTEGRAL COMUNITARIO DE LA HUACANA��6�   �� 6	  �� 6   � Language$ es-mx�6  $!�               :BIBLIOTECA:��6*  6P  �� 5P   
   $��michoacan.png��6   $��0��6'   $
��Left=�64   $��90��6O   $��Center=�6[   $��90��6v   $��10,5,0,5q�6�   �� 5Q   
   $��secretaria.jpg��6   $��0��6(   $��Right=�65   $��90��6Q   $��Center=�6]   $	��172��6x   $��0,5,7,5q�6�   5S      5T      