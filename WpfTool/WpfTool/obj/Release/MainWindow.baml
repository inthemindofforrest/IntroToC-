   M S B A M L   `   `   `  ���� B  >WpfTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfToolWpfTool      WpfTool.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfTool     -     � Title$  Mindful��$	��600��$��900         ��.��� -    �Name$ 
GridSystem������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF555555�� � Offset$ 0.007Q�� $ 	#FF979797��$ 1Q� � ColumnDefinitions �� $��8* ��� $
��190* ��� $	��25* �.+��� -    ��Name$ 	NameField��$��1��$
��Left=�$��	10,15,0,0q�$
��Wrap=�$��GUEST��$	��Top=�$��39��$	��156��$��20(� �� TextAlignment$ Center=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF818181��$ 0Q�� $ White��$ 1Q��� -   	 ��Name$	 	SignInOut��$��Sign In��$��2��$
��Left=�$��	10,10,0,0q�$	��Top=�$��79��$��39��$y�Hidden=��� -   $	 
PlayButton��$
��PLAY��$��1��$
��Left=�$��627,450,0,0q�$	��Top=�$	��133��$��45��$��36(����	#FF0E0000$y�Hidden=����� $	 0,1&�$	 0,0&�.��� $ 	#FF22FF00��$ 0Q�� $ 	#FF149300��$ 0.673Q�� $ 	#FF16A200��$ 0.317Q�� $ 	#FF0E6A00��$ 1Q��� -   
 ��Name$
 	ListOfExe��$��1��$
��Left=�$	��391��$��
529,59,0,0q�$	��Top=�$	��231��$y�Hidden=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF818183��$ 0Q�� $ White��$ 1Q��� -    ��Name$ 	UserImage��$��1��$
��Left=�$	��147��$��	13,59,0,0q�$	��Top=�$	��153�� J� OpacityMask
 �   ��� -    ��Name$ AddProgramBorder��
���   �$��1q�$��1��$
��Left=�$	��175��$��
10,320,0,0q�$	��Top=�$	��440��$y�Hidden=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF818181��$ 0Q�� $ White��$ 1Q��� -	   $ NameText��
���   �$��1q�$��1��$
��Left=�$��39��$��	10,15,0,0q�$	��Top=�$	��156��$y�Hidden=��� -
   $ ImageBorder��
���   �$��1q�$��1��$
��Left=�$	��147��$��	13,59,0,0q�$	��Top=�$	��147��$y�Hidden=��� -   $ ListOfExeBorder��
���   �$��1q�$��1��$
��Left=�$	��391��$��
529,59,0,0q�$	��Top=�$	��231��$y�Hidden=��� -   $ AddprogramText��$
��Wrap=�$��Add a Program:��$��20,330,648,216q�$��1���� -   $ PathText��$
��Wrap=�$��Application Path:��$��20,376,648,171q�$��1���� -   $ FileNameText��$
��Wrap=�$��Application file:��$��20,422,648,125q�$��1���� -    ��Name$ NewPath��$��1��$
��Left=�$��20��$��133,379,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��305��$y�Hidden=��� -   $ NewExe��$��1��$
��Left=�$��20��$��133,425,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��305��$y�Hidden=��� -   $	 ConfirmNewButton��$��Confirm��$��1��$
��Left=�$��186,450,0,0q�$	��Top=�$��76��$y�Hidden=��� -   $	 AddProgramButton��$��Browse��$��1��$
��Left=�$��229,338,0,0q�$	��Top=�$��43���� -   $	 RemoveButton��$��Remove��$��1��$
��Left=�$��529,450,0,0q�$	��Top=�$��98��$��45��$��24(����	#FF0E0000$y�Hidden=����� $	 0,1&�$	 0,0&�.��� $	 Red��$ 0Q�� $ 	#FF932800��$ 0.673Q�� $ 	#FFA23B00��$ 0.317Q�� $ 	#FF611200��$ 1Q��� -   $	 SettingsButton��$��2��$��Settings��$��1��$
��Left=�$��
720,10,0,0q�$	��Top=�$��50��$��39��$y�Hidden=��� -   $	 
BackButton��$
��Back��$��2��$
��Left=�$��0,15,0,0q�$	��Top=�$��75��$��49���� -   $ ChangePasswordText��$��1��$
��Left=�$��	0,399,0,0q�$
��Wrap=�$	��Top=�$��46��$	��272��$��22(��� $�Change password���� -   $ CurrentPasswordText��$��1��$
��Left=�$��
20,444,0,0q�$
��Wrap=�$	��Top=�$��33��$	��171��$��20(��� $�Current password:���� �� �� -   $ CurrentPasswordField��$��1��$
��Left=�$��33��$��196,444,0,0q�$
 Wrap=�$	��Top=�$	��162���� -   $ NewPasswordText��$��1��$
��Left=�$��
20,482,0,0q�$
��Wrap=�$	��Top=�$��33��$	��171��$��20(�$��New password:���� -   $ NewPasswordField��$��1��$
��Left=�$��33��$��196,482,0,0q�$
 Wrap=�$	��Top=�$	��162���� -   $ NewPasswordAgainText��$��1��$
��Left=�$��
20,520,0,0q�$
��Wrap=�$	��Top=�$��33��$	��171��$��20(��� $�New password:���� �� �� -   $ NewPasswordAgainField��$��1��$
��Left=�$��33��$��196,520,0,0q�$
 Wrap=�$	��Top=�$	��162���� -   $ 	ThemeText��$
��Left=�$��	0,324,0,0q�$
��Wrap=�$��Theme:��$	��Top=�$��55��$	��133��$��36(�$��1���� -   $	 
BlackTheme��$�� ��$
��Left=�$��140,330,0,0q�$	��Top=�$��41��$��41��$��1������ $ 0.5,1&� � MappingMode$ RelativeToBoundingBox=�$ 0.5,0&�.��� $ Black��$ 0Q�� $ 	#FFEBEBEB��$ 1Q�� $ Black��� $ 	#FFCDCDCD��$ 1Q��� -   $	 
WhiteTheme��$�� ��$
��Left=�$��205,330,0,0q�$	��Top=�$��41��$��41��
�������$��1���� -    $	 	BlueTheme��$�� ��$
��Left=�$��270,330,0,0q�$	��Top=�$��41��$��41��$��1������ $	 0,1&�$	 0,0&�.��� $ 	#FF0046FF��$ 0Q�� $ 	#FFEBEBEB��$ 1Q�� $ 	#FFDDDDDD��$ 1Q�� $ 	#FFCDCDCD��$ 1Q��� -!   $ ProfilePicText��$
��Left=�$��
369,45,0,0q�$
��Wrap=�$��Profile Picture:��$	��Top=�$��56��$	��246��$��36(�$��1���� -"   $	 SubmitButton��$��Submit��$��1��$
��Left=�$��43��$��389,477,0,0q�$	��Top=�$	��112���� -#    ��Name$ ShowPasswords��$��Show Passwords��$��1��$��196,404,396,131q�$��20(�G� -$    G�Name$ EncryptedPWCurrent��$��1��$
��Left=�$��196,445,0,0q�$	��Top=�$	��162��$��32��G� -%   $ EncryptedPWNewFirst��$��1��$
��Left=�$��196,483,0,0q�$	��Top=�$	��162��$��32��G� -&   $ EncryptedPWNewSecond��$��1��$
��Left=�$��196,521,0,0q�$	��Top=�$	��162��$��32���� -'   $ PasswordChangedText��$��1��$
��Left=�$��389,521,0,0q�$
��Wrap=�$��Password Changed��$	��Top=�$	��112��$ Center=�
���   ��� -(   $ 
BlackImage��$��1��$
��Left=�$��67��$��342,105,0,0q�$	��Top=�$��70��$��Images/Black.png���� -)   $ 	BlueImage��$��1��$
��Left=�$��67��$��443,105,0,0q�$	��Top=�$��70��$��Images/Blue.png���� -*   $ 
GreenImage��$��1��$
��Left=�$��67��$��545,105,0,0q�$	��Top=�$��70��$��Images/Green.png���� -+   $ RedImage��$��1��$
��Left=�$��67��$��392,191,0,0q�$	��Top=�$��70��$��Images/Red.png���� -,   $ 
WhiteImage��$��1��$
��Left=�$��67��$��493,191,0,0q�$	��Top=�$��70��$��Images/White.png���� --   $	 BlackButton��$�� ��$��1��$
��Left=�$��342,105,0,0q�$	��Top=�$��70��$��68����Z� �� -.   $	 
BlueButton��$�� ��$��1��$
��Left=�$��443,105,0,0q�$	��Top=�$��70��$��68����Z� �� -/   $	 GreenButton��$�� ��$��1��$
��Left=�$��545,105,0,0q�$	��Top=�$��70��$��68����Z� �� -0   $	 	RedButton��$�� ��$��1��$
��Left=�$��389,191,0,0q�$	��Top=�$��70��$��68����Z� �� -1   $	 WhiteButton��$�� ��$��1��$
��Left=�$��493,191,0,0q�$	��Top=�$��70��$��68����Z� 