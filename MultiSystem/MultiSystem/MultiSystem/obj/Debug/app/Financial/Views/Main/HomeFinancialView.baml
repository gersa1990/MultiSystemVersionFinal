   M S B A M L   `   `   `  ����F  BMultiSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:MultiSystem.app.Financial.Views.Controls(MultiSystem.app.Financial.Views.Controls  5      c6clr-namespace:MultiSystem.app.Financial.Views.Controls(MultiSystem.app.Financial.Views.Controls  5      �Eclr-namespace:MultiSystem.app.Financial.Views.Controls.PrivateSection7MultiSystem.app.Financial.Views.Controls.PrivateSection  5   	   <    6MultiSystem.app.Financial.Views.Main.HomeFinancialView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   FAdd6clr-namespace:MultiSystem.app.Financial.Views.Controls     5      Kservices6clr-namespace:MultiSystem.app.Financial.Views.Controls     5      ^adminControlEclr-namespace:MultiSystem.app.Financial.Views.Controls.PrivateSection     5   	     � Title$  Recursos financieros��5   	   $
��1024��5      $	��608��5	       � Left$ 0��5
       � WindowStartupLocation$ CenterScreen=�5   	   
 � Top$ 0��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      �� 5      $��32 �6   .+�5   
   �� -   5         ��Name$ controlMain��5      $
��auto��6+   $��1��69   $
��auto��6F    �� TabStripPlacement$
 Left=�6S   $��2��6l   .@�5      �� -   5         ��Name$ homeFinancialAdmin��5   -   $��Administrador��6   .��5      � ���	#FFE5E5E5.+�5      ;   5MultiSystem.app.Financial.Views.Controls.AdminControl  5      5      �� 5      -   5        $ registerServiceToUser��5   2   $��Registrar servicio��6   .��5      � ���	#FFE5E5E5.+�5      >   8MultiSystem.app.Financial.Views.Controls.RegisterService  5       5!      �� 5#      -   5        $��rePrintService��5#   3   $��Reimprimir servicio��6   .��5$      � ���	#FFE5E5E5.+�5%      D   >MultiSystem.app.Financial.Views.Controls.ReprintBillingService  5&      5'      �� 5(      -   5        $ reporterByTurn��5(   1   $��Reporte por turno��6   .��5)      � ���	#FFE5E5E5.+�5*      ;   5MultiSystem.app.Financial.Views.Controls.ReportByTurn  5+      5,      �� 5.      -   5        $ 
addService��5.   0   $��Agregar servicio��6   .��5/      � ���	#FFE5E5E5.+�50      9   3MultiSystem.app.Financial.Views.Controls.AddService  51      52      �� 54      -   5        $ editService��54   /   $��Editar servicio��6   .��55      � ���	#FFE5E5E5.+�56      :   4MultiSystem.app.Financial.Views.Controls.EditService  57      58      5:      �� 5<   
   -   5         ��Name$ rectangleBottom��5<      
���   �
���   �$
��auto��6I   $��2��6V   $��2��6d   �� 5=   
   -	   5        	 ��Name$	 clockBottom2��5=      $��Derechos reservados 2014
��6&   
�������$��14(�6a   $��2��6o   $��Right=�6}   $��Center=�6�   $��32��6�   $	��417��6�   �� 5>   
   -
   5        $	 	nameAdmin��5>      $��2��6   $��Label��60   $
��Left=�6@   $��Center=�6\   $	��495��6w   $��32��6�   
�������$��14(�6�   �� 5A   
   -   5        $ rectangleTop��5A      $��0��6*   $��	0,0,0,0.5q�67   ��5B      �� 5C      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5D      �  � Color$ 	#FFD60000��6#    � Offset$ 0Q�65   � 5E      $ 	#FF830000��6#   $ 1Q�65   5F      5H      �� 5I   
   $��Center=�6   $��169,11,140.149,11q�61   $
��Wrap=�6L   $��Center=�6`   $��78��6{   $��20(�6�   
�������$��Arial Black)�6�   $��450.851��6�   �� 6�   $�    HOSPITAL ��6�   �� 6�    � Language$ es-mx�6�   $�I��6  �� 6  $�NTEGRAL��6  �� 6"  $ es-mx�6&  $� ��67  �� 6B  $�COMUNITARIO ��6F  �� 6\  �� 6h  $ es-mx�6l  $�                      ��6}  �� 6�  $�DE LA HUACANA ��6�  �� 6�  �� 6�  $ es-mx�6�  $�                ��6�  �� 6�  $�SERVICIOS FINANCIEROS��6�  6  �� 5J   
   $A��;/MultiSystem;component/app/Library/Views/Home/michoacan.png��6   $��0��6U   $
��Left=�6b   $��90��6}   $��Center=�6�   $��90��6�   $��10,5,0,5q�6�   �� 5K   
   $B��</MultiSystem;component/app/Library/Views/Home/secretaria.jpg��6   $��0��6V   $��Right=�6c   $��90��6   $��Center=�6�   $	��172��6�   $��0,5,7,5q�6�   5M      5N      