   M S B A M L   `   `   `  ���� B  >WpfTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfToolWpfTool      WpfTool.SignIn   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfTool       � WindowStartupLocation$  CenterScreen=� � Title$ SignIn��$��232.635��$��413.573��.���  � RowDefinitions �� $	��17* ��� $	��12* �����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF646464�� � Offset$ 0Q�� $ 	#FFB8B8B8��$ 1Q� � ColumnDefinitions �� �� $��0* �.+��� -    ��Name$ UsernameText��$
��Left=�$��	10,10,0,0q�$
��Wrap=�$��UserName��$	��Top=�$��41��$	��124��	 �� TextAlignment$	 Center=�$��24(��� -   $ PasswordText��$
��Left=�$��	10,68,0,0q�$
��Wrap=�$��Password��$	��Top=�$��41��$	��124��$	 Center=�$��24(��� -   
 ��Name$
 Username��$
��Left=�$��41��$��
139,10,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��257��$��24(��� -    ��Name$ Submit��$��Submit��$
��Left=�$��281,31.333,0,0q�$	��Top=�$	��115��$��43��$��1��G� -    G�Name$ Password��$
��Left=�$��
139,68,0,0q�$	��Top=�$��42��$	��230��$��24(��� -   $ NewUserButton��$��	New User?��$
��Left=�$��10,52.333,0,0q�$	��Top=�$	��116��$��22��$��1���� -   $ Cancel��$��Cancel��$
��Left=�$��164,31.333,0,0q�$	��Top=�$	��112��$��43��$��1���� -   $ ErrorMessage��$
��Left=�$��139,115,0,0q�$
��Wrap=�$	��Top=�$	��257��$��30��$	 Center=�
���  ��$��2���� -	    ��Name$ ShowPasswordCheckBox��$�� ��$
��Left=�$��
375,81,0,0q�$	��Top=��� -
   $
 Unhidden��$
��Left=�$��41��$��
139,69,0,0q�$
 Wrap=�$	��Top=�$	��230��$��24(��� -   $ ForgotPasswordButton��$��Forgot Password?��$
��Left=�$��
24,109,0,0q�$	��Top=�$��94��$��10(�$��2��