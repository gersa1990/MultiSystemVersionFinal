   M S B A M L   `   `   `  ����  MultiSystem    MultiSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  
mainWindow��5   	    � Title$ MultiSystem��5	   	   $
��1024��5
      $	��608��5       � Left$ 0��5       � WindowStartupLocation$ CenterScreen=�5   	   
 � Top$ 0��5   	   .��5      � -   5         �Name$ mainGrid��5       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ rectangleTop��5      $��0��6*   $��	0,0,0,0.5q�67   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67   .��5      �  � Color$ 	#FFD60000��6#    � Offset$ 0Q�65   � 5      $ 	#FF830000��6#   $ 1Q�65   5      5!      �� 5"   
   $��Center=�6   $��169,15,70,15q�61   $
��Wrap=�6G   $��Center=�6[   $��70��6v   $��24(�6�   
�������$��Arial Black)�6�   $	��521��6�   �� 6�   $8�2       HOSPITAL INTEGRAL COMUNITARIO DE LA HUACANA��6�   6
  �� 5#   
   $A��;/MultiSystem;component/app/Library/Views/Home/michoacan.png��6   $��0��6U   $
��Left=�6b   $��90��6}   $��Center=�6�   $��90��6�   $��10,5,0,5q�6�   �� 5$   
   $B��</MultiSystem;component/app/Library/Views/Home/secretaria.jpg��6   $��0��6V   $��Right=�6c   $��90��6   $��Center=�6�   $	��172��6�   $��0,5,7,5q�6�   �� 5'   
   -   5         ��Name$ controlMain��5'      $
��auto��6*   $��1��68   $
��auto��6E    �� TabStripPlacement$
 Left=�6R   .@�5)      �� $
��Home��6   .��5*      � ���	#FFE5E5E5 5+      �� 5,      $	��87* �6+   �� 5-      $
��160* �6+   �� 5.      $	��76* �6+   �� 5/      $
��159* �6+   �� 50      $	��96* �6+   .+�52      �� -   5         ��Name$ btnGoLibrary��52      $
��Left=�65   $��	0,141,0,0q�6P   $	��Top=�6c   $	��156��6{   $	��184��6�   $��1��6�   .��53      �� $	��140��6%   $��96��62   .+�54      �� -   5        $��imageBtnLibrary��54   $   $ ��/app/Resources/library.png��6;   6b   �� 55      $��57��6(   �� 65   �� 6;   �� 6G   $�
Biblioteca��6K   6`   56      57      �� 58      -   5        $
��Left=�58      $��	0,141,0,0q�69   $	��Top=�6L   $	��154��6d   $	��180��6p   $��3��6}   .��59      �� $	��140��6%   $��96��62   .+�5:      �� -   5        $��imageBtnFinancial��5:   $   $��/app/Resources/money.png��6=   6b   �� 5;      �� 6)   $�Recursos��6-   �� 6?    � Language$ es-mx�6C   $� ��6T   �� 6_   �� 6k   $ es-mx�6o   �� 6�   $�financieros��6�   6�   5<      5=      5>      5?      �� 5A      $��	Acerca de��6   .��5B      � ���	#FFE5E5E55D      5E      5J      5K      5M      