   M S B A M L   `   `   `  ����B  >WpfTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfToolWpfTool  5   	       WpfTool.SignIn   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfTool     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ SignIn��5	   	   $��232.635��6   $��413.573��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $	��17* �6   �� 5      $	��12* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF646464��6    � Offset$ 0Q�61   � 5      $ 	#FFB8B8B8��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ UsernameText��5      $
��Left=�6*   $��	10,10,0,0q�6E   $
��Wrap=�6X   $��UserName��6l   $	��Top=�6|   $��41��6�   $	��124��6�   	 �� TextAlignment$	 Center=�6�   $��24(�6�   �� 5   
   -   5        $ PasswordText��5      $
��Left=�6*   $��	10,68,0,0q�6E   $
��Wrap=�6X   $��Password��6l   $	��Top=�6|   $��41��6�   $	��124��6�   $	 Center=�6�   $��24(�6�   �� 5   
   -   5        
 ��Name$
 Username��5      $
��Left=�6$   $��41��6?   $��
139,10,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��257��6�   $��24(�6�   6�   �� 5   
   -   5         ��Name$ Submit��5      $��Submit��6!   $
��Left=�62   $��281,31.333,0,0q�6M   $	��Top=�6e   $	��115��6}   $��43��6�   $��1��6�   G� 5   
   -   5         G�Name$ Password��5      $
��Left=�6(   $��
139,68,0,0q�6C   $	��Top=�6W   $��42��6o   $	��230��6{   $��24(�6�   6�   �� 5   
   -   5        $ NewUserButton��5      $��	New User?��6(   $
��Left=�6<   $��10,52.333,0,0q�6W   $	��Top=�6n   $	��116��6�   $��22��6�   $��1��6�   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $
��Left=�62   $��164,31.333,0,0q�6M   $	��Top=�6e   $	��112��6}   $��43��6�   $��1��6�   �� 5    
   -   5        $ ErrorMessage��5       $
��Left=�6*   $��139,115,0,0q�6E   $
��Wrap=�6Z   $	��Top=�6n   $	��257��6�   $��30��6�   $	 Center=�6�   
���  ��$��2��6�   �� 5!   
   -	   5         ��Name$ ShowPasswordCheckBox��5!      $�� ��61   $
��Left=�6<   $��
375,81,0,0q�6W   $	��Top=�6k   6�   �� 5"   
   -
   5        $
 Unhidden��5"      $
��Left=�6$   $��41��6?   $��
139,69,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��230��6�   $��24(�6�   6�   �� 5#   
   -   5        $ ForgotPasswordButton��5#      $��Forgot Password?��6/   $
��Left=�6J   $��
24,109,0,0q�6e   $	��Top=�6y   $��94��6�   $��10(�6�   $��2��6�   6�   5%      5&      