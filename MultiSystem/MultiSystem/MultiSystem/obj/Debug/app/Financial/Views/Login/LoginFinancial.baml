   M S B A M L   `   `   `  ����  MultiSystem:    4MultiSystem.app.Financial.views.Login.LoginFinancial   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          �Name$  Window��5       � Title$ LoginFinancial��5      $	��640��5      $	��480��5       � WindowStartupLocation$ CenterScreen=�5	       � 
ResizeMode$ NoResize=�5
       � WindowStyle$ 
ToolWindow=�6   .��5      � -   5         �Name$ 
LayoutRoot��5       � ColumnDefinitions 5      �� 5      $	��50* �6   �� 5      $	��99* �6   �� 5      $
��146* �6   �� 5      $
��292* �6   �� 5      $	��50* �6    � RowDefinitions 5      �� 5      $	��63* �6   �� 5      $
��110* �6   �� 5      $	��45* �6   �� 5      $	��45* �6   �� 5      $	��50* �6   �� 5      $
��133* �6   .+�5      �� -   5         ��Name$ userNameFinancial��5      $��2��6'   $��3��64   $��Center=�6D   $��30��6a   	 �� TextWrapping$
	 Wrap=�6m   $�� ��6�   $��Center=�6�   $	��206��6�   �� 5      $
��Left=�6   $��23��6'   $��377.15,239.661,0,0q�63   $
	 Wrap=�6O   $��TextBox��6c   $	��Top=�6r   $	��120��6�   �� 5       
���   �$
��Left=�6   $��60��66   
���   �$	��Top=�6Q   $	��634��6i   $��5��6u   �� 5!      -   5        
 ��Name$
 labelTittleLibrary��5!   
   $>��8Para poder entrar necesitas tener usuario y contraseña.��6&   $��0��6h   $��MS Reference Sans Serif)�6u    � Cursor$
 None��6�   $��10,10,10,1.16q�6�   $��Center=�6�   $��Center=�6�   $��52.688��6�   
�������$��18(�6  $��514.47��6(  $��1��67  $��3��6G  G� 5"      -   5         G�Name$ passwordFinancialNew��5"      $��3��6.   $��3��6;   $��Center=�6K   $��30��6h   $��Center=�6t   $	��206��6�   $��0q�6�   6�   �� 5#      $��Usuario��6
   $��2��6   $��Center=�6,   $��0q�6I   $��2��6T   $��Center=�6a   $��106.565��6|   �� 5$      $��Contraseña��6
   $��2��6   $��Center=�6/   $��19.374,9.645,19.374,9.999q�6L   $��3��6o   $��Center=�6|   $��106.565��6�   �� 5%      -   5        $��Cancelar��5%      $��3��6   $
��Left=�6.   $��0q�6I   $��4��6T   $��Center=�6a   $	��100��6|   ���	#FF890707
�������$��13.333(�6�   $��25��6�   6�   �� 5&      -   5        $��Entrar��5&      $��3��6   $��Right=�6,   $��0q�6H   $��4��6S   $��Center=�6`   $	��100��6{   ���	#FF065523
�������$��13.333(�6�   $��25��6�   6�   �� 5'      -   5        $
 consoleLogin��5'   
   $�� ��6    $��2��6+   $
��Left=�6;   $��0,47.15,0,0q�6V   $��1��6k   $	��Top=�6x   $��2��6�   $��435.937��6�   $��38.96��6�   $��16(�6�   ���	#00000000���	#FFFF0D0D6�   �� 5(      -	   5        $ passWordDescencrypted_��5(      $��3��6,   $��Center=�6<   $��30��6Y   $��0q�6e   $��3��6p   $
	 Wrap=�6}   $��Center=�6�   $	��206��6�   6�   �� 5)      -
   5         ��Name$ checkBoxSeePassword��5)      $	��Ver��6*   $��3��68   $
��Left=�6H   $��267.716,15.644,0,0q�6c   $��3��6   $	��Top=�6�   $��2��6�   $��62.673��6�   6�   5*      5+      