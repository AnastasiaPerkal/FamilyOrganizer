   M S B A M L   `   `   `  ����J  FFamilyOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FamilyOrganizerFamilyOrganizer  5   	   /    )FamilyOrganizer.FamilyOrganizerMessageBox   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:FamilyOrganizer     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�5	   	    � Title$ FamilyOrganizerMessageBox��5
   	   $	��150��5   	   $	��350��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         CloseButton �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 J� SnapsToDevicePixels��%�   &	        �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $	 button��6!   $��0q�5   !   #��z��5   !   
 . 5      5      5      5      5      .��5      � .+�5   
   �� 
���   �$��1q�6%   �� 5    
   -   5         ��Name$ CloseBtn��5       $��50��5!      $��50��5"       �� 	IsDefault . $��0q�5$        ButtonStyle#��[ 5%      $��0q�5)      $��Right=�5*      $	��Top=�5+      ��5,      �� 5-       �� ImageSource$ .\Resources\quit.png��6   5/      �� 50   
   -   5         ��Name$ MessageBoxLabel��50      $��Center=�51      $��Center=�52      $��60��53      $	��320��54      $��	helvetica)�55      $��Light"�56      $��20(�57      $��0 10 0 0q�58      59      5:      