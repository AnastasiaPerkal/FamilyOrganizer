   M S B A M L   `   `   `  ���� J  FFamilyOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FamilyOrganizerFamilyOrganizer       FamilyOrganizer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:FamilyOrganizer       � Title$  
MainWindow��$	��555��$	��700�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 	Resources    BackgroundSelectedBrush �� Color �� Opacity  ToggleBtnMouseOver �� ImageSource  ToggleBtnIsChecked  ToggleBtnStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName  	FontStyle��%x  &	        &	      &	 <     &	 ]     7  7  7  7  &	 w    �� $ Black��$	 0.1Q��� $ .\Resources\menu1.png���� $ .\Resources\menu1.png���� " d�.��� 	 � ��
 �� " d�.R��� $ border��#��z��#��z�� .  P�  �@J�IsMouseOver . . ��� $ border��8
   	 � ���� $ border��8
  	 � ��P�  �@d�	IsChecked$
 TrueY�. ��� $ border��8
  	 � ���� $ border��8
  	 � ���� " ��.��� 	 � ��$
 	helvetica)��� 	 � ��$
 Light"��� 	 � ��$
 Center=��� 	 � ��$

 Left=��� 	 � ��

 ������� 	 � ��$
 20(��� 	 � ��$
 0 10 0 0q�.��� .+�� -    �Name$
 Back��
�������.+�� -   $ Back1����  �� CornerRadius$ 10���  � ColumnDefinitions �� $��* ��� $��50 ��� $��10 � � RowDefinitions �� $��10 ��� $��50 ��� $��50 ��� $��* �.+�� -   $��0��$��3��
��������� -    ��Name$ CloseBtn��$��1��$��1��$��50��$��50��$��0q�  ButtonStyle#��[ $��0q����� $ .\Resources\quit.png���� -   $ 	LogoutBtn��$��1��$��2��$��50��$��50��$��0q�#��[ ���� $ .\Resources\logOut.png��� -   $ NavigationPnl��$
��Left=�$��65�����#c7cedf.+��� -    ��Name$ StackPnl��.+�� $��90��.+��� $��1��$��0��$��73 0 0 0q�$��M E N U��
�������$��22(�
������ $
��Left=�$��Center=�#��[ d� -    d�Name$ 	ToggleBtn��$��0��$	��Top=�$
��Left=�$��5,17,0,0q�$��55��$��55��$��0q�#��[ ���� $ .\Resources\menu.png�� j� Stretch$
 Fill=� � Triggers :�  :� RoutedEvent$ ToggleButton.Unchecked��.[��� .���� -	    ��Name$ HideStackPanel��.��W�  �� 
TargetName$ NavigationPnl�� �� TargetProperty$ Width� g� 	BeginTime$ 0:0:0X�  W� From$	  200X�	! W� To$! 65X�" g� Duration$" 0:0:0.2D�:� $ ToggleButton.Checked��.[��� .���� -
   $ ShowStackPanel��.��W� $ NavigationPnl��$ Width�$ 0:0:0X�$  65X�$	! 200X�$" 0:0:0.3D��� -   # ��Name$# LV��
������ 
������ $��Disabled=�.@��� -   $
��Left=�$��0 0 0 15q�.���� $ �� Orientation$$ 
Horizontal=�$	��230��.+��� -   $��generalImage��$��.\Resources\general.png��$
��Fill=�$��53��$��55���� $��General��$��10 0 0 0q�#��[ �� -   $
��Left=�$��0 0 0 15q�.���� $$ 
Horizontal=�$	��230��.+��� -   $��profileImage��$��.\Resources\edit.png��$
��Fill=�$��55��$��55���� $��Profile��$��10 0 0 0q�#��[ �� -   % ��Name$% 	FamilyTab��$
��Left=�$��0 0 0 15q�.���� $$ 
Horizontal=�$	��230��.+��� -   $��familyImage��$��.\Resources\family.png��$
��Fill=�$��-4 0 0 0q�$��60��$��50���� $��Family��$��10 0 0 0q�#��[ �� -   $% StatsTab��$
��Left=�$��0 0 0 15q�.���� $$ 
Horizontal=�$	��230��.+��� -   $��statisticsImage��$ ��.\Resources\statistics.png��$
��Fill=�$��55��$��55���� $��
Statistics��$��10 0 0 0q�#��[ �� -   $
��Left=�$��0 0 0 15q�.���� $$ 
Horizontal=�$	��230��.+��� -   $��expencesImage��$��.\Resources\money.png��$
��Fill=�$��55��$��55���� $��Expences��$��10 0 0 0q�#��[ �� -   $
��Left=�$��0 0 0 15q�.���� $$ 
Horizontal=�$	��230��.+��� -   $��	listImage��$��.\Resources\list.png��$
��Fill=�$��55��$��53���� $��Shopping list��$��10 0 0 0q�#��[ �� -   $
��Left=�$��0 0 0 15q�.���� $$ 
Horizontal=�$	��230��.+��� -   $��
diaryImage��$��.\Resources\diary.png��$
��Fill=�$��55��$��55���� $��Tasks��$��10 0 0 0q�#��[ ���� " ��.��� 	 � ��
 �� " ��.R��� $ Bd��$��50��#��z��#��z��#��z��& �� Padding#& z�� . ._��� #��z��# z #��z�� ]� ' ]� 
Conditions' �� ( �� Property( �@J�IsMouseOver) �� Value) . ./��� $ Bd��#
 [  	 � ���� $ Bd��#
 [  	 � ��]� ' �� ( �@��
IsSelected) . ./��� $ Bd��#
 [  	 � ���� $ Bd��#
 [  	 � ��